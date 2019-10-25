using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrinterHelpers.PrintersImplementations;

namespace PrinterHelpers
{
   public interface IPrinter
    {
        void Writeline(string str);
        void Write(string v);
    }
}
