namespace Training7.FolderWithFigures
{
    using System;

    class VectorOperations
    {
        public static double CalcLenghtVector(Point a, Point b)
        {
            return Math.Sqrt(((a.X - b.X) * (a.X - b.X)) + ((a.Y - b.Y) * (a.Y - b.Y)));
        }
    }
}
