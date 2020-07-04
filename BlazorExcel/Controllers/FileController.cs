using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;

namespace BlazorExcel.Controllers
{
    public class FileController : Controller
    {
        [Route("file")]
        public IActionResult Index()
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Sample Sheet");
            worksheet.Cell("A1").Value = "Hello World!";
            worksheet.Cell("A2").FormulaA1 = "=MID(A1, 7, 5)";
            worksheet.Cell("A3").Hyperlink = 
            workbook.SaveAs("HelloWorld.xlsx");
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();

            return File(content,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","info.xlsx");
        }
    }
}
