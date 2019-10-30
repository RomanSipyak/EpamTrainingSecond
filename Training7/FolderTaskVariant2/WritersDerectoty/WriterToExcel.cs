using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training7.FolderTaskVariant2.WritersDerectoty
{
    public class WriterToConsole : IWriterDerectory
    {
        public WriterToConsole(ShowerDirectory showerDerectoryInstance)
        {
            this.ShowerDerectoryInstance = showerDerectoryInstance;
        }

        public ShowerDirectory ShowerDerectoryInstance { get; private set; }

        public void ExpectDirectory()
        {
            Console.WriteLine("<////////////////ExpectDirectory////////////////>");
            Stopwatch myTimer = new Stopwatch();
            myTimer.Start();
            Console.WriteLine($"Count files in ExpectSet {this.ShowerDerectoryInstance.ExpectDirectory().Count}");
            foreach (FileInfo info in this.ShowerDerectoryInstance.ExpectDirectory())
            {
                Console.WriteLine("FullPath ==> {0}, FileName ==> {1}", info.FullName, info.Name);
            }

            Console.WriteLine($"time taken: {+myTimer.Elapsed}");
            Console.WriteLine("^////////////////ExpectDirectory////////////////^");
        }

        public void Intersection()
        {
            Console.WriteLine("<////////////////Intersection////////////////>");
            Stopwatch myTimer = new Stopwatch();
            myTimer.Start();
            Console.WriteLine($"Count files in ExpectSet {this.ShowerDerectoryInstance.Intersection().Count}");
            foreach (FileInfo info in this.ShowerDerectoryInstance.Intersection())
            {
                Console.WriteLine("FullPath ==> {0}, FileName ==> {1}", info.FullName, info.Name);
            }

            Console.WriteLine($"time taken: {+myTimer.Elapsed}");
            Console.WriteLine("^////////////////Intersection////////////////^");
        }

        public void SymmetricalDifference()
        {
            Console.WriteLine("<////////////////SymmetricalDifference////////////////>");
            Stopwatch myTimer = new Stopwatch();
            myTimer.Start();
            Console.WriteLine($"Count files in ExpectSet {this.ShowerDerectoryInstance.SymmetricalDifference().Count}");
            foreach (FileInfo info in this.ShowerDerectoryInstance.SymmetricalDifference())
            {
                Console.WriteLine("FullPath ==> {0}, FileName ==> {1}", info.FullName, info.Name);
            }

            Console.WriteLine($"time taken: {+myTimer.Elapsed}");
            Console.WriteLine("^////////////////SymmetricalDifference////////////////^");
        }
    }
}
