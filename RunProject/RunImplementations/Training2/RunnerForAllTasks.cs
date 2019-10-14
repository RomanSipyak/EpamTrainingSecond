using PrinterHelpers;
using PrinterHelpers.PrintersImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training2.Task1._3._5;

namespace RunProject.RunImplementations.Training2
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
            try
            {
                ClassWithExceptionsMethods.FibonachiWithExeption(5);
            }
            catch (StackOverflowException e)
            {
                Printer.Writeline(e.Message);
            }
            try
            {
                ClassWithExceptionsMethods.GetNumber(new int[] { 1, 2, 3 }, 5);
            }
            catch (IndexOutOfRangeException e)
            {
                Printer.Writeline(e.Message);
            }
            try
            {
                ClassWithExceptionsMethods.DoSomeMath(-2, 10);
            }
            catch (ArgumentException e)
            when (e.ParamName == "a")
            {
                Printer.Writeline(e.Message);
            }
            catch (ArgumentException e)
            when (e.ParamName == "b")
            {
                Printer.Writeline(e.Message);
            }
            try
            {
                ClassWithExceptionsMethods.DoSomeMath(5, 10);
            }
            catch (ArgumentException e)
            when (e.ParamName == "a")
            {
                Printer.Writeline(e.Message);
            }
            catch (ArgumentException e)
            when (e.ParamName == "b")
            {
                Printer.Writeline(e.Message);
            }
            return true;
        }
    }
}
