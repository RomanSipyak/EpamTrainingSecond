namespace RunProject
{
    using System;
    using System.Collections.Generic;
    using Logger;
    using PrinterHelpers.PrintersImplementations;
    using RunProject.RunImplementations.Training8;
    using RunProject.RunImplementations.Training9;

    public class Program
    {
        public static void Main(string[] args)
        {
            MyLogger mylogger = new MyLogger();
            mylogger.SrcLogger = new DataBaseLogger();
            try
            {
                Dictionary<string, IRun> menu = new Dictionary<string, IRun>();
                menu.Add("T1TaskAll", new RunImplementations.Training1.RunnerForAllTasks(new ConsolePrinter()));
                menu.Add("T2TaskAll", new RunImplementations.Training2.RunnerForAllTasks(new ConsolePrinter()));
                menu.Add("T3TaskAll", new RunImplementations.Training3.RunnerForAllTasks(new ConsolePrinter()));
                menu.Add("T5TaskAll", new RunImplementations.Training5.RunImplementationForSerializerCar(new ConsolePrinter()));
                menu.Add("T6TaskAll", new RunImplementations.Training6.ReflectionImplementation(new ConsolePrinter()));
                menu.Add("T7TaskAll", new RunImplementations.Training7.CircleAndRectangleRunImplementation(new ConsolePrinter()));
                menu.Add("T8TaskAll", new RunCalc());
                menu.Add("T9TaskAll", new RunnerForThreads(new ConsolePrinter()));
                bool exit = true;
                do
                {
                    Console.WriteLine("If you want to run Training1 AllTask write T1TaskAll ");
                    Console.WriteLine("If you want to run Training2 AllTask write T2TaskAll ");
                    Console.WriteLine("If you want to run Training3 AllTask write T3TaskAll ");
                    Console.WriteLine("If you want to run Training5 AllTask write T5TaskAll ");
                    Console.WriteLine("If you want to run Training5 AllTask write T5TaskAll ");
                    Console.WriteLine("If you want to run Training6 AllTask write T6TaskAll ");
                    Console.WriteLine("If you want to run Training6 AllTask write T7TaskAll ");
                    Console.WriteLine("If you want to run Training6 AllTask write T8TaskAll ");
                    Console.WriteLine("If you want to run Training6 AllTask write T9TaskAll ");
                    string key = Console.ReadLine();

                    if (menu.ContainsKey(key))
                    {
                        exit = menu[key].Run();
                    }
                    else
                    {
                        exit = false;
                    }
                }
                while (exit);
            }
            catch (Exception e)
            {
                mylogger.SrcLogger.WriteMessage(e);
                mylogger.SrcLogger.ReadMessage();
            }
        }
    }
}
