using ClosedXML.Excel;
using System.IO;
using System;

namespace ToolBox
{
    public class WriteToExcel
    {
        public WriteToExcel(string[] a, string[] b)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.AddWorksheet("WordsList");
            for (int i = 1; i < b.Length; i++)
            {
                worksheet.Cell(i, 1).Value = a[i-1];
                worksheet.Cell(i, 2).Value = b[i-1];
            }
            workbook.SaveAs("WordsList.xlsx");
        }
    }
}