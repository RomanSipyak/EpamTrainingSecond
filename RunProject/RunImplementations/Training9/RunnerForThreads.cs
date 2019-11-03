using PrinterHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training9;

namespace RunProject.RunImplementations.Training9
{
    class RunnerForThreads : IRun
    {
        public IPrinter Printer { get; set; } = new PrinterHelpers.PrintersImplementations.ConsolePrinter();

        public RunnerForThreads(IPrinter printer)
        {
            Printer = printer;
        }

        public bool Run()
        {
            try
            {
                Random random = new Random();
                TreadSummarize separ = new TreadSummarize();
                double[,] array = new double[3, 3];
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        array[i, j] = random.Next(1, 20);
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
                Console.WriteLine("aaaaaaaaaaaaaaaa");
                //foreach (double[,] a in separ.Separator(array, 9))
                //{
                //    //Console.WriteLine($"{a.ElementAt(0).GetLength(0)}");
                //    for (int i = 0; i < a.GetLength(0); i++)
                //    {
                //        for (int j = 0; j < a.GetLength(1); j++)
                //        {
                //            Console.Write($"a[{i},{j}] = {array[i, j]}");
                //        }

                //        Console.WriteLine();
                //    }
                //}
                Console.WriteLine($"{separ.CalculateSum(array, 3)}");
                Console.WriteLine($"{TreadSummarize.sum}");
                return true;
            }

            catch (Exception e)
            {
                Printer.Writeline(e.Message);
                Console.ReadKey();
                return false;
            }
        }
    }
}