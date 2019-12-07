namespace RunProject.RunImplementations.Training3
{
    using System;
    using System.Text;
    using global::Training3;
    using PrinterHelpers;
    using PrinterHelpers.PrintersImplementations;

    class RunnerForAllTasks : IRun
    {
        public RunnerForAllTasks(IPrinter printer)
        {
            this.Printer = printer;
        }

        public IPrinter Printer { get; set; } = new ConsolePrinter();

        public bool Run()
        {
            ShowerDirectory sd = new ShowerDirectory();
            string filesAndDerectories = sd.ShowerDirectoryAndFiles("C:\\Users\\GOOD\\source\\repos\\EpamTrainingSecond", new StringBuilder());
            this.Printer.Writeline(filesAndDerectories);
            this.Printer.Writeline(sd.SearchByRootPath("C:\\Users\\GOOD\\source\\repos\\EpamTrainingSecond", "with"));
            Console.ReadLine();
            return true;
        }
    }
}
