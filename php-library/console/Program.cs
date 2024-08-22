using System;
using Pchp.Core;


// create host for PHP code (Runtime Context):
using (var ctx = Context.CreateConsole(null))
{
    var pdf = new FPDF(ctx);
    pdf.AddPage();
    pdf.SetFont("Arial");
    pdf.Cell(40, 10, "Hello World!");
    pdf.Output("file.pdf", "file");
}
