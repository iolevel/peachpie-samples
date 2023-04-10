using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.JSInterop;
using Pchp.Core;

namespace webassembly.Services
{
    /// <summary>
    /// Service providing PeachPie (PHP) rendering and interoperability features.
    /// </summary>
    public class PhpInterop
    {
        IJSRuntime JS { get; }

        /// <summary>
        /// PHP request context.
        /// Represents a request lifecycle, so anything declared within this instance stays there.
        /// </summary>
        Context Context { get; }

        public PhpInterop(IJSRuntime js, Context context)
        {
            Debug.Assert(js is IJSInProcessRuntime);

            this.JS = js;
            this.Context = context;
            this.Context.Output = TextWriter.Null;

            // declare PHP function that calls a JS function
            this.Context.DeclareFunction("call_js_func", new Func<string, PhpValue[], PhpValue>((fnname, args) =>
            {
                // PHP values -> Object[]
                var clrargs = new object[args != null ? args.Length : 0];
                for (int i = 0; i < clrargs.Length; i++)
                {
                    clrargs[i] = args[i].ToClr();
                }

                // invoke JS function
                var value = ((IJSInProcessRuntime)JS).Invoke<object>(fnname, clrargs);

                // wrap CLR object to PHP value
                return PhpValue.FromClr(value);
            }));
        }

        /// <summary>
        /// Do "require".
        /// Throw on error.
        /// </summary>
        public object? Require(string path)
        {
            //return Context.Include("", path, once: true, throwOnError: true);
            var script = Context.TryGetDeclaredScript(path); // find compiled script file by name (relative path, Unix directory separators)
            if (script.IsValid)
            {
                script.Evaluate(this.Context, this.Context.Globals, null);
                return null;
            }

            throw new ArgumentException($"File '{path}' could not be found.");
        }

        /// <summary>
        /// Render a script file and return it's output.
        /// </summary>
        public string View(string path)
        {
            var sb = new StringBuilder();
            var output = new StringWriter(sb);
            var oldoutput = this.Context.Output;

            try
            {
                this.Context.Output = output;

                // perform "include", outputing to our StringBuilder
                Require(path);
            }
            finally
            {
                output.Flush();
                this.Context.Output = oldoutput;
            }

            //
            return sb.ToString();
        }

        /// <summary>
        /// Call a (declared) PHP function.
        /// </summary>
        public PhpValue Call(string function, params PhpValue[] args) => this.Context.Call(function, args);
    }
}
