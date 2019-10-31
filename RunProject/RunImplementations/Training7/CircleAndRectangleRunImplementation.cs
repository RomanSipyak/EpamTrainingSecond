using PrinterHelpers;
using PrinterHelpers.PrintersImplementations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training7;
using Training7.FolderTaskVariant2;
using Training7.FolderTaskVariant2.WritersDerectoty;
using Training7.FolderWithFigures;
using Training7.TaskVariant1;

namespace RunProject.RunImplementations.Training7
{
    public class CircleAndRectangleRunImplementation : IRun
    {

        public IPrinter Printer { get; set; } = new ConsolePrinter();

        public CircleAndRectangleRunImplementation(IPrinter printer)
        {
            Printer = printer;
        }

        public bool Run()
        {
            try
            {

                ////Circle Work
                Printer.Writeline("////////////Work with rectangles////////////");
                Cirlce circle1 = new Cirlce(new Point(1, 1), new Point(2, 1));
                Printer.Writeline($"cirlse ==> {circle1}");
                Cirlce circle2 = new Cirlce(new Point(-1, 1), new Point(-1, 2));
                Printer.Writeline($"Intersection of Two Circles {circle1} AND {circle2}");
                foreach (Point point in circle1.Intersection(circle2))
                {
                    Printer.Writeline(point.ToString());
                }
                circle1.Move(1, 3);
                Printer.Writeline($"cirlse after move(1,3) ==> {circle1}");
                circle1.ChangeSize(new Point(-1, 1), new Point(-1, 5));
                Printer.Writeline($"cirlse after changeSize(-1, 1),(-1, 5) ==> {circle1}");
                Printer.Writeline($"Biggest between {circle1},{circle2} ===> {circle1.Biggest(circle2)}");
                Printer.Writeline($"Least between {circle1},{circle2} ===> {circle1.Least(circle2)}");
                ////Circle Work
                ////Rectangle Work
                Printer.Writeline("////////////Work with rectangles////////////");
                Rectagle rectangle1 = new Rectagle(new Point(1, 1), new Point(2, -3));
                Printer.Writeline($"rectangre ==> {rectangle1}");
                Rectagle rectangle2 = new Rectagle(new Point(-1, 1), new Point(5, -3));
                Printer.Writeline($"Intersection of Two Rectangles {rectangle1} AND {rectangle2} ==> {rectangle1.Intersection(rectangle2)}");

                rectangle1.Move(1, 3);
                Printer.Writeline($"rectangle after move(1,3) ==> {rectangle1}");
                rectangle1.ChangeSize(new Point(-1, 1), new Point(2, -2));
                Printer.Writeline($"rectangle1 after changeSize(-1, 1),(-1, 5) ==> {rectangle1}");
                Printer.Writeline($"Biggest between {rectangle1},{rectangle2} ===> {rectangle1.Biggest(rectangle2)}");
                Printer.Writeline($"Least between {rectangle1},{rectangle2} ===> {rectangle1.Least(rectangle2)}");
                ////Rectangle Work
                Printer.Writeline("////////////Work with Derictories////////////");
                ShowerDirectory showerDirectory = new ShowerDirectory();
                Stopwatch myTimer = new Stopwatch();
                myTimer.Start();
                showerDirectory.SymmetricalDifference();
                showerDirectory.Intersection();
                showerDirectory.ExpectDirectory();
                WriterToConsole writerToConsole = new WriterToConsole(showerDirectory);
                WriterToExcel writerToExcel = new WriterToExcel(showerDirectory);
                writerToConsole.SymmetricalDifference();
                writerToConsole.Intersection();
                writerToConsole.ExpectDirectory();
                writerToExcel.SymmetricalDifference();
                writerToExcel.Intersection();
                writerToExcel.ExpectDirectory();
                myTimer.Stop();
                Printer.Writeline($"time taken: {+myTimer.Elapsed}");
                ListsComparer a = new ListsComparer();
                a.ReadValues();
                //ExcelTest ecxel = new ExcelTest();
                //ecxel.Write();
                return true;
            }

            catch (Exception e)
            {
                Printer.Writeline(e.Message);
                Console.ReadKey();
                return false;
            }
        }
    }
}
