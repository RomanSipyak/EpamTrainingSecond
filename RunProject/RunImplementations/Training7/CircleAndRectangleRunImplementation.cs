using PrinterHelpers;
using PrinterHelpers.PrintersImplementations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training7;
using Training7.FolderTaskVariant2;

namespace RunProject.RunImplementations.Training7
{
    public class FileNameComparer : IEqualityComparer<FileInfo>
    {
        public bool Equals(FileInfo x, FileInfo y)
        {
            if (x == y)
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            return string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(FileInfo obj)
        {
            return obj.Name.GetHashCode();
        }
    }

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
                Cirlce circle1 = new Cirlce(new Point(1, 1), new Point(2, 1));
                Cirlce circle2 = new Cirlce(new Point(-1, 1), new Point(-1, 2));
                List<Point> results = circle1.Intersection(circle2);
                foreach (Point point in results)
                {
                    Printer.Writeline(point.Tostring());
                }
                //string[] result = ShowerDirectory.ShowAllFiles("C:\\Users\\GOOD\\Desktop\\web-service");
                //string[] result2 = ShowerDirectory.ShowAllFiles("C:\\Users\\GOOD\\Desktop\\web-service 2");
                //HashSet<FileInfo> folder1 = new HashSet<FileInfo>();
                //HashSet<FileInfo> folder2 = new HashSet<FileInfo>();

                //foreach (string res in result)
                //{ Console.WriteLine(res);
                //    System.IO.FileInfo fi = new System.IO.FileInfo(res);
                //    folder1.Add(fi);
                //    Console.WriteLine("{0}", fi.Name);
                //}
                //Console.WriteLine("folder1{0}", folder1.Count);
                //Console.WriteLine("????????????????????????????????????????????????????????");
                //foreach (string res in result2)
                //{
                //    System.IO.FileInfo fi = new System.IO.FileInfo(res);
                //    folder2.Add(fi);
                //    Console.WriteLine("{0}", fi.Name);
                //}
                //Console.WriteLine("folder2{0}", folder2.Count);
                ////Console.WriteLine("{0}", a.Count);
                ////Console.WriteLine("????????????????????????????????????????????????????????");
                ////a = a.Distinct(new FileNameComparer()).ToHashSet();
                ////Console.WriteLine(a.Count);
                //Console.WriteLine("????????????????????????????????????????????????????????");
                //HashSet<FileInfo> except1 =folder1.Except(folder2, new FileNameComparer()).ToHashSet();
                //HashSet<FileInfo> except2 =folder2.Except(folder1, new FileNameComparer()).ToHashSet();
                //HashSet<FileInfo> exceptIntersect = except1.Concat(except2).ToHashSet();
                ////HashSet<FileInfo> exceptIntersect = folder1.Intersect(folder2, new FileNameComparer()).ToHashSet();
                ////foreach (FileInfo res in except)
                ////{
                ////    Console.WriteLine("{0}", res.Name);
                ////}
                //foreach (FileInfo res in exceptIntersect)
                //{
                //    Console.WriteLine("{0}", res.Name);
                //}
                ////Console.WriteLine("expect{0}", except.Count);
                //Console.WriteLine("expect{0}", exceptIntersect.Count);
                ShowerDirectory showerDirectory= new ShowerDirectory();
               HashSet<FileInfo> exceptIntersect =  showerDirectory.SymmetricalDifference();
                foreach (FileInfo res in exceptIntersect)
                {
                    Console.WriteLine("{0}", res.Name);
                }
                Console.ReadKey();
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
                return false;
            }


        }
    }
}
