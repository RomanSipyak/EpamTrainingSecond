using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterHelpers.PrintersImplementations
{
    public class ConsolePrinter : IPrinter
    {
        public void Writeline(string str)
        {
            Console.WriteLine(str);
        }
    }
}
