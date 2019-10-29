using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training8
{
    public class PrinterToConsole : Printer
    {
        public List<double> Read()
        {
            List<double> valuesOfOperation = new List<double>();
            Console.WriteLine("Write first value");
            double first = Convert.ToDouble(Console.ReadLine());
            valuesOfOperation.Add(first);
            Console.WriteLine("Write second value");
            double second = Convert.ToDouble(Console.ReadLine());
            valuesOfOperation.Add(second);
            return valuesOfOperation;
        }

        public void Write(string a)
        {
            Console.WriteLine(a);
        }
    }
}
