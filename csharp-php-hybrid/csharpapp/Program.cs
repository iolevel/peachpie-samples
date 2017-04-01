using System;
using System.Reflection;
using Pchp.Core;
using Pchp.Core.Reflection;

namespace csharpapp
{
    public class Program
    {
        static void Main()
        {
            // sideload assembly containing compiled PHP code:            
            Context.AddScriptReference(Assembly.Load(new AssemblyName("phplib")));

            // create host for PHP code (Runtime Context):
            using (var ctx = Context.CreateConsole())
            {
                // declare global function in PHP runtime context
                ctx.DeclareFunction(RoutineInfo.CreateUserRoutine("is_valid_url",
                    new Func<string, bool>((url) => {
                        return new Uri(url).IsAbsoluteUri;
                    })));

                // call the global code from "class-user.php" which declares class
                ctx.Include("", "inc/class-user.php");

                //
				dynamic u1 = ctx.Create("User", "Jacob", "https://example.org", "email@jacob.org");
				u1.Authenticate();
				
                var u2 = new DotNetUser(ctx, "Jacob", "https://example.org", "email@jacob.org");
                u2.Authenticate();
            }
        }
    }
}
