using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training7.FolderWithFigures
{
    class VectorOperations
    {
        public static double CalcLenghtVector(Point a, Point b)
        {
            return Math.Sqrt(((a.X - b.X) * (a.X - b.X)) + ((a.Y - b.Y) * (a.Y - b.Y)));
        }
    }
}
