using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Training7.TaskVariant1
{
    public class ListsComparer
    {
        private FileStream fileStream = null;

        public void CompareAndPrintUniqueValues()
        {
            try
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
            catch (ConfigurationErrorsException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<string> UniqueValues(List<string> listvalues)
        {
            try
            {
                var g = listvalues.GroupBy(i => i).ToList();
                g.RemoveAll(this.RemoveRepeat);
                listvalues.Clear();
                foreach (var grp in g)
                {
                    listvalues.Add(grp.Key);
                }

                return listvalues;
            }
            catch (ArgumentNullException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<string> ReadValues()
        {
            try
            {
                string pathToFileWithLists = ConfigurationManager.AppSettings["PathToFileWithLists"].ToString();
                XSSFWorkbook workbook;
                if (File.Exists(pathToFileWithLists))
                {
                    this.fileStream = new FileStream(pathToFileWithLists, FileMode.Open, FileAccess.ReadWrite);
                    workbook = new XSSFWorkbook(this.fileStream);
                    this.fileStream.Close();
                }
                else
                {
                    this.fileStream = new FileStream(pathToFileWithLists, FileMode.Create, FileAccess.ReadWrite);
                    workbook = new XSSFWorkbook(this.fileStream);
                    this.fileStream.Close();
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
                                    if (cell != null)
                                    {
                                        cell.SetCellType(CellType.String);
                                        listValues.Add(cell.StringCellValue);
                                    }
                                }
                            }
                        }
                    }
                }

                return listValues;
            }
            catch (ConfigurationErrorsException e)
            {
                throw e;
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (this.fileStream != null)
                {
                    this.fileStream.Close();
                }
            }
        }

        private bool RemoveRepeat(IGrouping<string, string> grp)
        {
            return grp.Count() >= 2;
        }
    }
}