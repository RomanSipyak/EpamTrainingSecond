using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training7.TaskVariant1
{
    public class ListsComparer
    {
        bool RemoveRepeat(IGrouping<string, int> grp)
        {
            return grp.Count() >= 2;
        }

        //public void Lol()
        //{
        //    var l1 = new List<int>() { 1, 2, 3, 4, 5, 2, 2, 2, 4, 4, 4, 1 };

        //    var g = l1.GroupBy(i => i).ToList();
        //    g.RemoveAll(RemoveRepeat);
        //    foreach (var grp in g)
        //    {
        //        Console.WriteLine("{0} {1}", grp.Key, grp.Count());
        //    }
        //}

        public void ReadValues()
        {
            //Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            FileStream sw;
            var workbook = new XSSFWorkbook();
            if (File.Exists("C:\\Users\\GOOD\\Desktop\\test.xls"))
            {
                sw = new FileStream("C:\\Users\\GOOD\\Desktop\\test.xls", FileMode.Open, FileAccess.ReadWrite);
                workbook = new XSSFWorkbook(sw);
            }
            else
            {
                sw = new FileStream("C:\\Users\\GOOD\\Desktop\\test.xls", FileMode.Create, FileAccess.ReadWrite);
                workbook = new XSSFWorkbook(sw);
            }

            ISheet sheet = null;
            string[] collumsKays = ConfigurationManager.AppSettings["collumsKays"].Split(',');
            List<string> listValues = new List<string>();
            if (workbook.NumberOfSheets != 0)
            {
                for (int i = 0; i < workbook.NumberOfSheets; i++)
                {
                    sheet = workbook.GetSheetAt(i); // assuming 0 is the worksheet index
                    for (int j = 0; j <= sheet.LastRowNum; j++)
                    {
                        //if (j == 11) Debugger.Break();
                        var row = sheet.GetRow(j);
                        if (row != null)
                        {
                            for (int k = 0; k < collumsKays.Length; k++)
                            {
                                var cell = row.GetCell(Convert.ToInt32(collumsKays[k]));
                                //Console.Write("{0}\t", cell);
                                //Console.Write("{0}\t", workbook.GetSheetName(i));
                                //Console.Write("{0}\t", Convert.ToInt32(collumsKays[k]));
                                if (cell != null)
                                {
                                    cell.SetCellType(CellType.String);
                                    //Console.Write("{0}\t", cell.StringCellValue);
                                    listValues.Add(cell.StringCellValue);
                                }
                            }
                            //Console.WriteLine();
                        }
                    }
                }
            }
            else
            {
            }

            sw.Close();
        }
    }
}