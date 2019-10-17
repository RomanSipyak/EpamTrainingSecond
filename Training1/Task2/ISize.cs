using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainig1.Task2
{
    public interface ISize
    {
        int Height { get; set; }

        int Width { get; set; }

        double Perimetr();
    }
}
