using PrinterHelpers;
using PrinterHelpers.PrintersImplementations;
using RunProject.RunImplementations.Training1;
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
            menu.Add("T1TaskAll", new RunnerForAllTasks(new ConsolePrinter()));
            bool exit = true;
            do
            {
                Console.WriteLine("If you want run Training1 AkkTask write T1TaskAll ");
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
