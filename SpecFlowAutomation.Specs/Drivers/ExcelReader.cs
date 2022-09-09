using System.IO;
using System.Linq;
using System.Text;
using OfficeOpenXml;

namespace SpecFlowAutomation.Specs.Drivers
{
    public static class ExcelReader
    {
        static string projectPath = Path.GetFullPath(@"..\..\..\");

        public static void ReadFile()
        {
            ReadExcel();
        }

        private static void ReadExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;

            string fullPathToExcel = projectPath + "Data\\inputdata.xlsx"; //ie C:\Temp\YourExcel.xls

            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(fullPathToExcel)))
            {
                var myWorksheet = xlPackage.Workbook.Worksheets.First(); //select sheet here
                var totalRows = myWorksheet.Dimension.End.Row;
                var totalColumns = myWorksheet.Dimension.End.Column;

                var sb = new StringBuilder(); //this is your data
                for (int rowNum = 1; rowNum <= totalRows; rowNum++) //select starting row here
                {
                    var row = myWorksheet.Cells[rowNum, 1, rowNum, totalColumns]
                        .Select(c => c.Value == null ? string.Empty : c.Value.ToString());
                    sb.AppendLine(string.Join(",", row));
                }
            }
        }
    }
}