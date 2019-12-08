﻿namespace Training7.FolderWithFigures
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

        public override string ToString()
        {
            return $"X ==> {this.X}, Y ==> {this.Y}";
        }
    }
}
