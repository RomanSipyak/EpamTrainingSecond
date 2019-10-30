namespace Training7.FolderTaskVariant2.WritersDerectoty
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    public class WriterToConsole : IWriterDerectory
    {
        private delegate HashSet<FileInfo> DirectoryOperation();

        public WriterToConsole(ShowerDirectory showerDerectoryInstance)
        {
            this.ShowerDerectoryInstance = showerDerectoryInstance;
        }

        public ShowerDirectory ShowerDerectoryInstance { get; private set; }

        public void ExpectDirectory()
        {
            this.WriteToConsole(this.ShowerDerectoryInstance.ExpectDirectory);
        }

        public void Intersection()
        {
            this.WriteToConsole(this.ShowerDerectoryInstance.Intersection);
        }

        public void SymmetricalDifference()
        {
            this.WriteToConsole(this.ShowerDerectoryInstance.SymmetricalDifference);
        }

        private void WriteToConsole(DirectoryOperation operation)
        {
            Console.WriteLine($"<////////////////{operation.Method.Name}////////////////>");
            Stopwatch myTimer = new Stopwatch();
            myTimer.Start();
            Console.WriteLine($"Count files in ExpectSet {operation().Count}");
            foreach (FileInfo info in operation())
            {
                Console.WriteLine("FullPath ==> {0}, FileName ==> {1}", info.FullName, info.Name);
            }

            Console.WriteLine($"time taken: {+myTimer.Elapsed}");
            Console.WriteLine($"^////////////////{operation.Method.Name}////////////////^");
        }
    }
}
