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
        private FileStream sw = null;

        public void CompareAndPrintUniqueValues()
        {
            if (ConfigurationManager.AppSettings["TargetForUniqueValues"].ToString().Equals("ConsolePrinter"))
            {
                new ConsolePrinter().Print(this.UniqueValues(this.ReadValues()));
            }

            if (ConfigurationManager.AppSettings["TargetForUniqueValues"].ToString().Equals("FilePrinter"))
            {
                new FilePrinter().Print(this.UniqueValues(this.ReadValues()));
            }
        }



        public List<string> UniqueValues(List<string> listvalues)
        {
            var g = listvalues.GroupBy(i => i).ToList();
            g.RemoveAll(RemoveRepeat);
            listvalues.Clear();
            foreach (var grp in g)
            {
                listvalues.Add(grp.Key);
                Console.WriteLine("{0} {1}", grp.Key, grp.Count());
            }
            return listvalues;
        }

        public List<string> ReadValues()
        {
            //Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            try
            {
                XSSFWorkbook workbook;
                if (File.Exists("C:\\Users\\GOOD\\Desktop\\test.xls"))
                {
                    sw = new FileStream("C:\\Users\\GOOD\\Desktop\\test.xls", FileMode.Open, FileAccess.ReadWrite);
                    workbook = new XSSFWorkbook(sw);
                    sw.Close();
                }
                else
                {
                    sw = new FileStream("C:\\Users\\GOOD\\Desktop\\test.xls", FileMode.Create, FileAccess.ReadWrite);
                    workbook = new XSSFWorkbook(sw);
                    sw.Close();
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

                return listValues;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }

        private bool RemoveRepeat(IGrouping<string, string> grp)
        {
            return grp.Count() >= 2;
        }
    }
}