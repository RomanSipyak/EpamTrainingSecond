using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training7
{
    public class ExcelTest
    {
        Microsoft.Office.Interop.Excel.Application oXL;
        Microsoft.Office.Interop.Excel._Workbook oWB;
        Microsoft.Office.Interop.Excel._Worksheet oSheet;
        Microsoft.Office.Interop.Excel.Range oRng;

        public void Write()
        {
            try
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet sheet1 = workbook.CreateSheet("Sheet1");
                sheet1.CreateRow(0).CreateCell(0).SetCellValue("This is a Sample");
                int x = 1;

                Console.WriteLine("Start at " + DateTime.Now.ToString());
                for (int i = 1; i <= 70000; i++)
                {
                    IRow row = sheet1.CreateRow(i);
                    for (int j = 0; j < 15; j++)
                    {
                        row.CreateCell(j).SetCellValue(x++);
                    }
                }

                Console.WriteLine("End at " + DateTime.Now.ToString());

                FileStream sw = File.Create("C:\\Users\\GOOD\\Desktop\\test.xls");
                workbook.Write(sw);
                sw.Close();

                Console.Read();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}