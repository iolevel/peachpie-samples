using Pchp.Core;
using Pchp.Core.Reflection;
using System;
using System.Reflection;

namespace csharpapp
{
    public class Program
    {
        static void Main()
        {
            // sideload assembly containing compiled PHP code:            
            Context.AddScriptReference(Assembly.Load(new AssemblyName("phplib")));

            // create host for PHP code (Runtime Context):
            using (var ctx = Context.CreateEmpty())
            {
                // declare a global variable in PHP runtime context
                ctx.Globals["x"] = (PhpValue)"Hello from C#";

                // // declare global function in PHP runtime context
                // ctx.DeclareFunction(RoutineInfo.CreateUserRoutine("foo",
                //     new Func<string>(() => {
                //         return "Hello from lambda!";
                //     }));

                // call the global code from "main.php"
                ctx.Include(null, "main.php");

                // call PHP function defined in 'main.php'
                ctx.Call("demo", new object[]{ });
            }
        }
    }
}
