﻿// <copyright file="WriterToExcel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Training7.FolderTaskVariant2.WritersDerectoty
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;

    public class WriterToExcel : IWriterDerectory
    {
        private FileStream fileStream = null;

        public WriterToExcel(ShowerDirectory showerDerectoryInstance)
        {
            this.ShowerDerectoryInstance = showerDerectoryInstance;
        }

        private delegate HashSet<FileInfo> DirectoryOperation();

        public ShowerDirectory ShowerDerectoryInstance { get; private set; }

        public void ExpectDirectory()
        {
            WriteToExcel(this.ShowerDerectoryInstance.ExpectDirectory);
        }

        public void Intersection()
        {
            WriteToExcel(this.ShowerDerectoryInstance.Intersection);
        }

        public void SymmetricalDifference()
        {
            WriteToExcel(this.ShowerDerectoryInstance.SymmetricalDifference);
        }

        private void WriteToExcel(DirectoryOperation operation)
        {
            try
            {
                string targetToOutput = ConfigurationManager.AppSettings["TargetToOutput"].ToString();
                var workbook = new XSSFWorkbook();
                if (File.Exists(targetToOutput))
                {
                    this.fileStream = new FileStream(targetToOutput, FileMode.Open/*, FileAccess.ReadWrite, FileShare.ReadWrite*/);
                    workbook = new XSSFWorkbook(this.fileStream);
                    this.fileStream.Close();
                }
                else
                {
                    this.fileStream = new FileStream(targetToOutput, FileMode.Create);
                    this.fileStream.Close();
                    workbook = new XSSFWorkbook();
                }

                //this.fileStream = new FileStream("C:\\Users\\GOOD\\Desktop\\test.xls", FileMode.Create, FileAccess.ReadWrite);

                ISheet sheet = null;
                bool notContain = true;
                if (workbook.NumberOfSheets != 0)
                {
                    for (int i = 0; i < workbook.NumberOfSheets; i++)
                    {
                        if (workbook.GetSheetName(i).Equals($"{operation.Method.Name}"))
                        {
                            //workbook.RemoveSheetAt(i);
                            notContain = false;
                            sheet = workbook.GetSheet($"{operation.Method.Name}");
                            break;
                        }
                        else
                        {
                            notContain = true;
                        }
                    }
                }

                if (File.Exists(targetToOutput))
                {
                    this.fileStream = new FileStream(targetToOutput, FileMode.Truncate/*, FileAccess.ReadWrite*/);
                }

                if (notContain)
                {
                    sheet = workbook.CreateSheet($"{operation.Method.Name}");

                    var row = sheet.CreateRow(0);
                    var row2 = sheet.CreateRow(1);
                    var row3 = sheet.CreateRow(2);
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
                    row.CreateCell(1);
                    row2.CreateCell(0);
                    row2.CreateCell(1);
                    row3.CreateCell(0, CellType.String).SetCellValue("FullPath");
                    row3.Cells[0].CellStyle = cellStyleBorderAndColorYellow;
                    row3.CreateCell(1, CellType.String).SetCellValue("FileName");
                    row3.Cells[1].CellStyle = cellStyleBorderAndColorYellow;
                    var cra = new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 1);
                    var cra2 = new NPOI.SS.Util.CellRangeAddress(1, 1, 0, 1);
                    sheet.AddMergedRegion(cra);
                    sheet.AddMergedRegion(cra2);
                    ICell cell = sheet.GetRow(0).GetCell(0);
                    cell.SetCellType(CellType.String);
                    cell.SetCellValue($"{operation.Method.Name}");
                    cell.CellStyle = cellStyleBorderAndColorGreen;
                    sheet.GetRow(0).GetCell(1).CellStyle = cellStyleBorderAndColorGreen;
                    ICell cell2 = sheet.GetRow(1).GetCell(0);
                    cell2.SetCellType(CellType.String);
                    cell2.SetCellValue($"Count files in ExpectSet {this.ShowerDerectoryInstance.SymmetricalDifference().Count}");
                    cell2.CellStyle = cellStyleBorderAndColorGreen;
                    sheet.GetRow(1).GetCell(1).CellStyle = cellStyleBorderAndColorGreen;

                    int x = 3;

                    foreach (FileInfo info in this.ShowerDerectoryInstance.SymmetricalDifference())
                    {
                        row = sheet.CreateRow(x);
                        row.CreateCell(0).SetCellValue(info.FullName);
                        row.CreateCell(1).SetCellValue(info.Name);
                        x++;
                    }
                }
                else
                {
                    var row = sheet.GetRow(0) == null ? sheet.CreateRow(0) : sheet.GetRow(0);
                    var row2 = sheet.GetRow(1) == null ? sheet.CreateRow(1) : sheet.GetRow(1);
                    var row3 = sheet.GetRow(2) == null ? sheet.CreateRow(2) : sheet.GetRow(2);

                    var row3Cell0 = row3.GetCell(0) == null ? row3.CreateCell(0) : row3.GetCell(0);
                    var row3Cell1 = row3.GetCell(1) == null ? row3.CreateCell(1) : row3.GetCell(1);
                    row3Cell0.SetCellValue("FilePath");
                    row3Cell1.SetCellValue("FileName");
                    ICell cell = sheet.GetRow(0).GetCell(0);
                    var row0Cell0 = row.GetCell(0) == null ? row.CreateCell(0) : row.GetCell(0);
                    row0Cell0.SetCellValue($"{operation.Method.Name}");
                    var row2Cell0 = row2.GetCell(0) == null ? row2.CreateCell(0) : row2.GetCell(0);
                    row2Cell0.SetCellValue($"Count files in ExpectSet {this.ShowerDerectoryInstance.SymmetricalDifference().Count}");
                    int x = 3;
                    foreach (FileInfo info in this.ShowerDerectoryInstance.SymmetricalDifference())
                    {
                        if (sheet.GetRow(x) == null)
                        {
                            row = sheet.CreateRow(x);
                        }
                        else
                        {
                            row = sheet.GetRow(x);
                        }

                        if (row.GetCell(0) != null)
                        {
                            row.GetCell(0).SetCellValue(info.FullName);
                        }
                        else
                        {
                            row.CreateCell(0).SetCellValue(info.FullName);
                        }

                        if (row.GetCell(1) != null)
                        {
                            row.GetCell(1).SetCellValue(info.Name);
                        }
                        else
                        {
                            row.CreateCell(1).SetCellValue(info.Name);
                        }

                        x++;
                    }
                }

                sheet.AutoSizeColumn(0);
                sheet.AutoSizeColumn(1);
                workbook.Write(this.fileStream);
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