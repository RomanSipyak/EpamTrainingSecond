using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training7.TaskVariant1
{
    public class ConsolePrinter : IWriter
    {
        public void Print(List<string> list)
        {
            Console.WriteLine("Unique elements {0}", list.Count);
            foreach (string value in list)
            {
                Console.WriteLine(value);
            }
        }
    }
}
