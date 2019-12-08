// <copyright file="RunnerForAllTasks.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

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
            this.Printer.Writeline("Write number of Month");
            uint numBerOfMonth = Convert.ToUInt32(Console.ReadLine());
            this.Printer.Writeline(MonthColection.GetMonthByNumber(numBerOfMonth));
            this.Printer.Writeline("Enum.GetValues and Enum.GetNames are sorted by the values in the enumeration");
            foreach (Colors value in Enum.GetValues(typeof(Colors)))
            {
                this.Printer.Writeline(value + $"=> {(int)value}");
            }

            this.Printer.Writeline("Sorted Enum by extencion method");
            foreach (Colors value in Enum<Colors>.SortedValues)
            {
                this.Printer.Writeline(value + $"=> {(int)value}");
            }

            this.Printer.Writeline($"Min = > {LongRangeTask.OutputLongRange(LongRange.Min)}");
            this.Printer.Writeline($"Max = > {LongRangeTask.OutputLongRange(LongRange.Max)}");
            Console.ReadKey();
            return true;
        }
    }
}
