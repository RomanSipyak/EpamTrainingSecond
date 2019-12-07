namespace RunProject.RunImplementations.Training1
{
    using System;
    using PrinterHelpers;
    using PrinterHelpers.PrintersImplementations;
    using Trainig1.Task1;
    using Trainig1.Task3;
    using Trainig1.Task4;
    using Trainig1.Task5;

    public class RunnerForAllTasks : IRun
    {
        public RunnerForAllTasks(IPrinter printer)
        {
            this.Printer = printer;
        }

        public IPrinter Printer { get; set; } = new ConsolePrinter();

        public bool Run()
        {
            Person person = new Person("Roma", "Sypiak", 21);
            this.Printer.Writeline(person.GetElder(15));
            this.Printer.Writeline(person.GetElder(21));
            uint n = Convert.ToUInt32(Console.ReadLine());
            this.Printer.Writeline(MonthColection.GetMonthByNumber(n));
            foreach (var value in Enum<Colors>.SortedValues)
            {
                Console.WriteLine(value);
            }

            this.Printer.Writeline($"Min = > {LongRangeTask.OutputLongRange(LongRange.Min)}");
            this.Printer.Writeline($"Max = > {LongRangeTask.OutputLongRange(LongRange.Max)}");
            Console.ReadKey();
            return true;
        }
    }
}
