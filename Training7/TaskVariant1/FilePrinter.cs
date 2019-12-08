namespace Training7.TaskVariant1
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;

    public class FilePrinter : IWriter
    {
        private FileStream fileStream = null;

        public void Print(List<string> list)
        {
            try
            {
                string targetPath = ConfigurationManager.AppSettings["TargetFilePath"].ToString();

                var workbook = new XSSFWorkbook();
                if (File.Exists(targetPath))
                {
                    this.fileStream = new FileStream(targetPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                    workbook = new XSSFWorkbook(this.fileStream);
                    this.fileStream.Close();
                }
                else
                {
                    this.fileStream = new FileStream(targetPath, FileMode.Create, FileAccess.ReadWrite);
                    workbook = new XSSFWorkbook();
                    workbook.CreateSheet("Sheet1");
                    workbook.Write(this.fileStream);
                    this.fileStream.Close();
                }

                ISheet sheet = null;

                if (workbook.NumberOfSheets != 0)
                {
                    for (int i = 0; i < workbook.NumberOfSheets; i++)
                    {
                        if (workbook.GetSheetName(i).Equals("UnicueElements"))
                        {
                            this.fileStream = new FileStream(targetPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                            sheet = workbook.GetSheet("UnicueElements");
                            //workbook.Remove(sheet);
                            workbook.RemoveSheetAt(workbook.GetSheetIndex(sheet));
                            workbook.Write(this.fileStream);
                            this.fileStream.Close();
                            break;
                        }
                    }
                }

                if (File.Exists(targetPath))
                {
                    this.fileStream = new FileStream(targetPath, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                }

                sheet = workbook.CreateSheet("UnicueElements");

                var row = sheet.CreateRow(0);

                var cellStyleBorder = workbook.CreateCellStyle();
                cellStyleBorder.BorderBottom = BorderStyle.Thin;
                cellStyleBorder.BorderLeft = BorderStyle.Thin;
                cellStyleBorder.BorderRight = BorderStyle.Thin;
                cellStyleBorder.BorderTop = BorderStyle.Thin;
                cellStyleBorder.Alignment = HorizontalAlignment.Center;
                cellStyleBorder.VerticalAlignment = VerticalAlignment.Center;
                var cellStyleBorderAndColorGreen = workbook.CreateCellStyle();
                cellStyleBorderAndColorGreen.CloneStyleFrom(cellStyleBorder);
                cellStyleBorderAndColorGreen.FillPattern = FillPattern.SolidForeground;
                ((XSSFCellStyle)cellStyleBorderAndColorGreen).SetFillForegroundColor(new XSSFColor(new byte[] { 198, 239, 206 }));
                var cellStyleBorderAndColorYellow = workbook.CreateCellStyle();
                cellStyleBorderAndColorYellow.CloneStyleFrom(cellStyleBorder);
                cellStyleBorderAndColorYellow.FillPattern = FillPattern.SolidForeground;
                ((XSSFCellStyle)cellStyleBorderAndColorYellow).SetFillForegroundColor(new XSSFColor(new byte[] { 255, 235, 156 }));

                row.CreateCell(0);
                ICell cell = sheet.GetRow(0).GetCell(0);
                cell.SetCellType(CellType.String);
                cell.SetCellValue($"Unique elements {list.Count}");
                cell.CellStyle = cellStyleBorderAndColorGreen;
                int x = 1;
                foreach (string uniqeValue in list)
                {
                    row = sheet.CreateRow(x);
                    var cellWithValue = row.CreateCell(0);
                    cellWithValue.SetCellValue(uniqeValue);
                    cellWithValue.CellStyle = cellStyleBorderAndColorYellow;
                    x++;
                }

                sheet.AutoSizeColumn(0);
                workbook.Write(this.fileStream);
                this.fileStream.Close();
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
    }
}
