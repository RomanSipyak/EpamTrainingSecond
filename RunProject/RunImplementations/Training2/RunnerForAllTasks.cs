namespace RunProject.RunImplementations.Training2
{
    using System;
    using global::Training2.Task1._3._5;
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
            try
            {
                ClassWithExceptionsMethods.FibonachiWithExeption(5);
            }
            catch (StackOverflowException e)
            {
                this.Printer.Writeline(e.Message);
            }

            try
            {
                ClassWithExceptionsMethods.GetNumber(new int[] { 1, 2, 3 }, 5);
            }
            catch (IndexOutOfRangeException e)
            {
                this.Printer.Writeline(e.Message);
            }

            try
            {
                ClassWithExceptionsMethods.DoSomeMath(-2, 10);
            }
            catch (ArgumentException e)
            when (e.ParamName == "a")
            {
                this.Printer.Writeline(e.Message);
            }
            catch (ArgumentException e)
            when (e.ParamName == "b")
            {
                this.Printer.Writeline(e.Message);
            }

            try
            {
                ClassWithExceptionsMethods.DoSomeMath(5, 10);
            }
            catch (ArgumentException e)
            when (e.ParamName == "a")
            {
                this.Printer.Writeline(e.Message);
            }
            catch (ArgumentException e)
            when (e.ParamName == "b")
            {
                this.Printer.Writeline(e.Message);
            }

            return true;
        }
    }
}
