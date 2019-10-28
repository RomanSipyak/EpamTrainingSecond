// <copyright file="Point.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Training7
{
    public class Point
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public string Tostring()
        {
            return $"X ==> {this.X}, Y ==> {this.Y}";
        }
    }
}
