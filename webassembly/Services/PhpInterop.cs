using System.Text;
using Pchp.Core;

namespace webassembly.Services
{
    /// <summary>
    /// Service providing PeachPie (PHP) rendering and interoperability features.
    /// </summary>
    public class PhpInterop
    {
        Context Context { get; }

        public PhpInterop(Context context)
        {
            this.Context = context;
        }

        public string View(string fname)
        {
            var script = Context.TryGetDeclaredScript(fname);
            if (script.IsValid)
            {
                var sb = new StringBuilder();
                var output = new StringWriter(sb);

                try
                {
                    Context.Output = output;
                    script.Evaluate(Context, PhpArray.NewEmpty(), null);
                }
                finally
                {
                    Context.Output = null;
                }
                //
                return sb.ToString();
            }

            throw new ArgumentException($"File '{fname}' could not be found.");
        }
    }
}
