using PrinterHelpers;
using PrinterHelpers.PrintersImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, IRun> menu = new Dictionary<string, IRun>();
            menu.Add("T1TaskAll", new RunImplementations.Training1.RunnerForAllTasks(new ConsolePrinter()));
            menu.Add("T2TaskAll", new RunImplementations.Training2.RunnerForAllTasks(new ConsolePrinter()));
            menu.Add("T3TaskAll", new RunImplementations.Training3.RunnerForAllTasks(new ConsolePrinter()));
            bool exit = true;
            do
            {
                Console.WriteLine("If you want run Training1 AkkTask write T1TaskAll ");
                Console.WriteLine("If you want run Training2 AkkTask write T2TaskAll ");
                Console.WriteLine("If you want run Training3 AkkTask write T3TaskAll ");
                string key = Console.ReadLine();

                if (menu.ContainsKey(key))
                {
                    exit = menu[key].Run();
                }
                else
                {
                    exit = false;
                }
            } while (exit);
        }
    }
}
