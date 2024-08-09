// See https://aka.ms/new-console-template for more information
using Infragistics.Documents.Excel;

Console.WriteLine("Hello, World!");
Workbook workbook1 = new Workbook();
Worksheet worksheet1 = workbook1.Worksheets.Add("Sheet 1");
worksheet1.Rows[0].Cells[0].Value = 42;
worksheet1.Columns[0].AutoFitWidth();
workbook1.Save("Workbook1.xls");