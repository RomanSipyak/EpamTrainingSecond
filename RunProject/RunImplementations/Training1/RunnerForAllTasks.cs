using PrinterHelpers;
using PrinterHelpers.PrintersImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainig1.Task1;
using Trainig1.Task3;
using Trainig1.Task4;
using Trainig1.Task5;

namespace RunProject.RunImplementations.Training1
{
    public class RunnerForAllTasks : IRun
    {
        public IPrinter Printer { get; set; } = new ConsolePrinter();

        public RunnerForAllTasks(IPrinter printer)
        {
            Printer = printer;
        }
        public bool Run()
        {
            Person person = new Person("Roma", "Sypiak", 21);
            Printer.Writeline(person.GetElder(15));
            Printer.Writeline(person.GetElder(21));
            uint n = Convert.ToUInt32(Console.ReadLine());
            Printer.Writeline(MonthColection.GetMonthByNumber(n));
            foreach (var value in Enum<Colors>.SortedValues)
            {
                Console.WriteLine(value);
            }
            Printer.Writeline($"Min = > {LongRangeTask.OutputLongRange(LongRange.Min)}");
            Printer.Writeline($"Max = > {LongRangeTask.OutputLongRange(LongRange.Max)}");
            Console.ReadKey();
            return true;
        }
    }
}
