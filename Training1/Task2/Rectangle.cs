// <copyright file="Rectangle.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Trainig1.Task2
{
    public struct Rectangle : ISize, ICoordinates
    {
        public Rectangle(int height, int width, int x, int y)
        {
            this.Height = height;
            this.Width = width;
            this.X = x;
            this.Y = y;
        }

        public int Height { get; set; }

        public int Width { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        double ISize.Perimetr()
        {
            return 2 * (this.Height + this.Width);
        }
    }
}
