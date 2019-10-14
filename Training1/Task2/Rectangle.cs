using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainig1.Task2
{
    struct Rectangle : ISize, ICoordinates
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        Rectangle(int Height, int Width, int X, int Y)
        {
            this.Height = Height;
            this.Width = Width;
            this.X = X;
            this.Y = Y;
        }

        double ISize.Perimetr()
        {
            return 2 * (Height + Width);
        }
    }
}
