using System;
using System.Reflection;
using Pchp.Core;
using Pchp.Core.Reflection;
using Pchp.Core.Utilities;

namespace csharpapp
{
    public class Program
    {
        static void Main()
        {
            var ctx = ContextExtensions.CurrentContext;

            // declare global function in PHP runtime context
            ctx.DeclareFunction("is_valid_url", new Func<string, bool>((url) =>
            {
                return new Uri(url).IsAbsoluteUri;
            }));

            // call the global code from "class-user.php" which declares class
            ctx.Include("", "class-user.php");

            //
            var u1 = new User("Everyone", "https://www.example.org/", "example@example.com");
            u1.Authenticate();

            dynamic u2 = ctx.Create("User", "Jacob", "https://example.org", "email@jacob.org");
            u2.Authenticate();

            var u3 = new DotNetUser("Jacob", "https://example.org", "email@jacob.org");
            u3.Authenticate();
        }
    }
}
