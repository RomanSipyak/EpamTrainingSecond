namespace RunProject.RunImplementations.Training9
{
    using System;
    using global::Training9;
    using PrinterHelpers;

    public class RunnerForThreads : IRun
    {
        public RunnerForThreads(IPrinter printer)
        {
            this.Printer = printer;
        }

        public IPrinter Printer { get; set; } = new PrinterHelpers.PrintersImplementations.ConsolePrinter();

        public bool Run()
        {
            try
            {
                Random random = new Random();
                TreadSummarize separ = new TreadSummarize();
                double[,] array = new double[4, 10];
                double sum = 0;
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        array[i, j] = random.Next(1, 20);
                        sum += array[i, j];
                    }
                }

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write($"a[{i},{j}] = {array[i, j]} ");
                    }

                    Console.WriteLine();
                }

                this.Printer.Writeline("///////////////////////");
                this.Printer.Writeline($"{sum}");
                this.Printer.Writeline($"{separ.CalculateSum(array, 100)}");
                this.Printer.Writeline($"{separ.Sum}");
                return true;
            }
            catch (Exception e)
            {
                this.Printer.Writeline(e.Message);
                Console.ReadKey();
                return false;
            }
        }
    }
}