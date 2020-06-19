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
            // create host for PHP code (Runtime Context):
            using (var ctx = Context.CreateConsole(null))
            {
                var pdf = new FPDF(ctx);
                pdf.AddPage();
                pdf.SetFont("Arial");
                pdf.Cell(40, 10, "Hello World!");
                pdf.Output("F", "tuto1.pdf");
            }
        }
    }
}
