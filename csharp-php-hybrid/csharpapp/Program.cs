using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using Pchp.Core;
using Pchp.Core.Reflection;
using Pchp.Core.Utilities;

namespace csharpapp
{
    public class Program
    {
        // lazily create `Context` per thread
        static AsyncLocal<Context> s_ctx = new AsyncLocal<Context>();

        static void Main(string[] args)
        {
            // Acquire PHP Context:
            // Context is a single-threaded object manntaining state of PHP program.
            // There are several ways of getting/creating the object, see https://docs.peachpie.io/api/ref/context/ for details

            // ContextExtensions.CurrentContext can be overriden, 
            // by default it would create a context per thread without output

            // 1/ we can either override the `CurrentContext` provider
            //    which allows us to seamlessly use PHP classes in C# without specifying `Context`
            ContextExtensions.CurrentContextProvider = () => s_ctx.Value ??= Context.CreateConsole(null, args);
            var ctx = ContextExtensions.CurrentContext; // calls our provider once per thread (for details see System.Threading.AsyncLocal)

            // 2/ or we can just create the `Context` instance
            //using var ctx = Context.CreateConsole(null, args); // create default console context

            // .php script files are compiled in `phplib.dll` assembly;
            // Reflect the scripts
            Context.AddScriptReference(typeof(User).Assembly); // or Assembly.Load("phplib")

            // declare global function in Context
            ctx.DeclareFunction("is_valid_url", new Func<string, bool>((url) =>
            {
                return new Uri(url).IsAbsoluteUri;
            }));

            // invoke the script "class-user.php"
            // The script declares class User in Context
            ctx.Include("", "class-user.php");

            // invoke the script "functions.php"
            // require_once semantic
            // the script declares function is_valid_email() in Context
            ctx.Include("", "functions.php", once: true, throwOnError: true);

            // call function is_valid_email(...)
            // global functions have to be declared and called using Context.Call():
            Debug.Assert((bool)ctx.Call("is_valid_email", "test@example.org"));

            // classes can be used as they are:
            var u1 = new User("Everyone", "https://www.example.org/", "example@example.com");
            u1.Authenticate();

            // classes can also be created dynamically:
            dynamic u2 = ctx.Create("User", "Jacob", "https://example.org", "email@jacob.org");
            u2.Authenticate();

            var u3 = new DotNetUser("Jacob", "https://example.org", "email@jacob.org");
            u3.Authenticate();
        }
    }
}
