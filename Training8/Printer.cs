using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training8
{
    public interface Printer
    {
        void Write(string a);
        List<double> Read();
    }
}
