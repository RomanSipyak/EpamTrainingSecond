using PrinterHelpers;
using PrinterHelpers.PrintersImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training3;

namespace RunProject.RunImplementations.Training3
{
    class RunnerForAllTasks : IRun
    {
        public IPrinter Printer { get; set; } = new ConsolePrinter();

        public RunnerForAllTasks(IPrinter printer)
        {
            Printer = printer;
        }
        public bool Run()
        {
            ShowerDirectory sd = new ShowerDirectory();
            String filesAndDerectories = sd.ShowerDirectoryAndFiles("C:\\Users\\GOOD\\source\\repos\\EpamTrainingSecond", new StringBuilder());
            Printer.Writeline(filesAndDerectories);
            Printer.Writeline(sd.SearchByRootPath("C:\\Users\\GOOD\\source\\repos\\EpamTrainingSecond","with"));
            Console.ReadLine();
            return true;
        }
    }
}
