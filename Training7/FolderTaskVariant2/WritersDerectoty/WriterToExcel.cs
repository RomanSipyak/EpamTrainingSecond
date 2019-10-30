using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training7.FolderTaskVariant2.WritersDerectoty
{
    public class WriterToExcel : IWriterDerectory
    {

        public WriterToExcel(ShowerDirectory showerDerectoryInstance)
        {
            this.ShowerDerectoryInstance = showerDerectoryInstance;
        }

        public ShowerDirectory ShowerDerectoryInstance { get; private set; }

        public void ExpectDirectory()
        {
            throw new NotImplementedException();
        }

        public void Intersection()
        {
            throw new NotImplementedException();
        }

        public void SymmetricalDifference()
        {
            Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            var workbook = new XSSFWorkbook();
            var sheet = workbook.CreateSheet("SymmetricalDifference");
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
            cell.SetCellValue("SymmetricalDifference");
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

            sheet.AutoSizeColumn(0);
            sheet.AutoSizeColumn(1);

            //IWorkbook workbook = new XSSFWorkbook();
            //ISheet sheet1 = workbook.CreateSheet("Sheet1");

            //ICellStyle rowstyle = workbook.CreateCellStyle();
            //rowstyle.FillForegroundColor = IndexedColors.Red.Index;
            //rowstyle.FillPattern = FillPattern.SolidForeground;

            //IRow cell12 = sheet1.CreateRow(0);
            //cell12.m = sheet1.CreateRow(0).CreateCell(1);
            //    iSetCellValue("SymmetricalDifference");
            //sheet1.CreateRow(1).CreateCell(0).SetCellValue($"Count files in ExpectSet {this.ShowerDerectoryInstance.SymmetricalDifference().Count}");
            //IRow row = sheet1.CreateRow(2);
            //row.RowStyle = rowstyle;
            //row.CreateCell(0).SetCellValue($"FullPath");
            //row.CreateCell(1).SetCellValue($"FileName");
            //int x = 3;

            //foreach (FileInfo info in this.ShowerDerectoryInstance.SymmetricalDifference())
            //{
            //    row = sheet1.CreateRow(x);
            //    row.CreateCell(0).SetCellValue(info.FullName);
            //    row.CreateCell(1).SetCellValue(info.Name);
            //    x++;
            //}
            //row = sheet1.CreateRow(x);
            //row.CreateCell(0).SetCellValue("SymmetricalDifference");
            //Console.WriteLine("End at " + DateTime.Now.ToString());
            FileStream sw = File.Create("C:\\Users\\GOOD\\Desktop\\test.xls");
            workbook.Write(sw);
            sw.Close();
        }
    }
}