using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training7.TaskVariant1
{
    public class FilePrinter : IWriter
    {
        public void Print(List<string> list)
        {
            string targetPath = ConfigurationManager.AppSettings["TargetFilePath"].ToString();
            FileStream sw;
            var workbook = new XSSFWorkbook();
            if (File.Exists(targetPath))
            {
                sw = new FileStream(targetPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                workbook = new XSSFWorkbook(sw);
                sw.Close();
            }
            else
            {
                sw = new FileStream(targetPath, FileMode.Create, FileAccess.ReadWrite);
                sw.Close();
                workbook = new XSSFWorkbook();
            }

            ISheet sheet = null;

            if (workbook.NumberOfSheets != 0)
            {
                for (int i = 0; i < workbook.NumberOfSheets; i++)
                {
                    if (workbook.GetSheetName(i).Equals("UnicueElements"))
                    {

                        sheet = workbook.GetSheet("UnicueElements");
                        workbook.Remove(sheet);
                        break;
                    }
                }
            }

            if (File.Exists(targetPath))
            {
                sw = new FileStream(targetPath, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
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
            //row2.CreateCell(0);
            //row2.CreateCell(1);
            //row3.CreateCell(0, CellType.String).SetCellValue("FullPath");
            //row3.Cells[0].CellStyle = cellStyleBorderAndColorYellow;
            //row3.CreateCell(1, CellType.String).SetCellValue("FileName");
            //row3.Cells[1].CellStyle = cellStyleBorderAndColorYellow;
            //var cra = new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 1);
            //var cra2 = new NPOI.SS.Util.CellRangeAddress(1, 1, 0, 1);
            //sheet.AddMergedRegion(cra);
            //sheet.AddMergedRegion(cra2);
            ICell cell = sheet.GetRow(0).GetCell(0);
            cell.SetCellType(CellType.String);
            cell.SetCellValue($"Unique elements {list.Count}");
            cell.CellStyle = cellStyleBorderAndColorGreen;
            //sheet.GetRow(0).GetCell(1).CellStyle = cellStyleBorderAndColorGreen;
            //ICell cell2 = sheet.GetRow(1).GetCell(0);
            //cell2.SetCellType(CellType.String);
            //cell2.SetCellValue($"Count files in ExpectSet {this.ShowerDerectoryInstance.SymmetricalDifference().Count}");
            //cell2.CellStyle = cellStyleBorderAndColorGreen;
            //sheet.GetRow(1).GetCell(1).CellStyle = cellStyleBorderAndColorGreen;

            int x = 1;
            foreach (string uniqeValue in list)
            {
                row = sheet.CreateRow(x);
                row.CreateCell(0).SetCellValue(uniqeValue);
                x++;
            }
            sheet.AutoSizeColumn(0);
            workbook.Write(sw);
            sw.Close();
        }
        //else
        //{
        //    sheet = workbook.CreateSheet("UnicueElements");

        //    var row = sheet.CreateRow(0);

        //    var cellStyleBorder = workbook.CreateCellStyle();
        //    cellStyleBorder.BorderBottom = BorderStyle.Thin;
        //    cellStyleBorder.BorderLeft = BorderStyle.Thin;
        //    cellStyleBorder.BorderRight = BorderStyle.Thin;
        //    cellStyleBorder.BorderTop = BorderStyle.Thin;
        //    cellStyleBorder.Alignment = HorizontalAlignment.Center;
        //    cellStyleBorder.VerticalAlignment = VerticalAlignment.Center;
        //    var cellStyleBorderAndColorGreen = workbook.CreateCellStyle();
        //    cellStyleBorderAndColorGreen.CloneStyleFrom(cellStyleBorder);
        //    cellStyleBorderAndColorGreen.FillPattern = FillPattern.SolidForeground;
        //    ((XSSFCellStyle)cellStyleBorderAndColorGreen).SetFillForegroundColor(new XSSFColor(new byte[] { 198, 239, 206 }));
        //    var cellStyleBorderAndColorYellow = workbook.CreateCellStyle();
        //    cellStyleBorderAndColorYellow.CloneStyleFrom(cellStyleBorder);
        //    cellStyleBorderAndColorYellow.FillPattern = FillPattern.SolidForeground;
        //    ((XSSFCellStyle)cellStyleBorderAndColorYellow).SetFillForegroundColor(new XSSFColor(new byte[] { 255, 235, 156 }));

        //    row.CreateCell(0);

        //    ICell cell = sheet.GetRow(0).GetCell(0);
        //    cell.SetCellType(CellType.String);
        //    cell.SetCellValue($"Unique elements {list.Count}");
        //    cell.CellStyle = cellStyleBorderAndColorGreen;
        //    int x = 1;
        //    foreach (string uniqeValue in list)
        //    {
        //        row = sheet.CreateRow(x);
        //        row.CreateCell(0).SetCellValue(uniqeValue);
        //        x++;
        //    }
        //}
        
    }
}
