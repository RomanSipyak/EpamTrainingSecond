// <copyright file="Rectangle.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Training7.FolderWithFigures
{
    public class Rectagle : IFigure<Rectagle>
    {
        public Rectagle(Point leftTopPoint, Point rightBottomPoin)
        {
            this.LeftTopPoint = leftTopPoint;
            this.RightBottomPoint = rightBottomPoin;
        }

        public double LengthVerticalSide => VectorOperations.CalcLenghtVector(this.LeftTopPoint, new Point(this.LeftTopPoint.X, this.RightBottomPoint.Y));

        public double LengthHotizontalSide => VectorOperations.CalcLenghtVector(this.LeftTopPoint, new Point(this.RightBottomPoint.X, this.LeftTopPoint.Y));

        public Point LeftTopPoint { get; set; }

        public Point RightBottomPoint { get; set; }

        public static bool operator <(Rectagle rectangle, Rectagle rectangle2)
        {
            return rectangle.Perimetr() < rectangle2.Perimetr() ? true : false;
        }

        public static bool operator >(Rectagle rectangle, Rectagle rectangle2)
        {
            return rectangle.Perimetr() > rectangle2.Perimetr() ? true : false;
        }

        public void Move(double moveByX, double moveByY)
        {
            this.LeftTopPoint = new Point(this.LeftTopPoint.X + moveByX, this.LeftTopPoint.Y + moveByY);
            this.RightBottomPoint = new Point(this.RightBottomPoint.X + moveByX, this.RightBottomPoint.Y + moveByY);
        }

        public Rectagle Intersection(Rectagle rec)
        {
            if (this.RightBottomPoint.Y > rec.LeftTopPoint.Y
                || this.LeftTopPoint.Y < rec.RightBottomPoint.Y
                || this.LeftTopPoint.X > rec.RightBottomPoint.X
                || this.RightBottomPoint.X < rec.LeftTopPoint.X)
            {
                return null;
            }
            else
            {
                Point leftTopPoint = new Point(this.Min(this.LeftTopPoint.Y, rec.LeftTopPoint.Y), this.Max(this.LeftTopPoint.X, rec.LeftTopPoint.X));
                Point rightBottomPoint = new Point(this.Max(this.RightBottomPoint.Y, rec.RightBottomPoint.Y), this.Min(this.RightBottomPoint.X, rec.RightBottomPoint.X));
                return new Rectagle(leftTopPoint, rightBottomPoint);
            }
        }

        public Rectagle Least(Rectagle rectagle2)
        {
            return this < rectagle2 ? this : rectagle2;
        }

        public Rectagle Biggest(Rectagle rectagle2)
        {
            return this > rectagle2 ? this : rectagle2;
        }

        public void ChangeSize(Point point, Point point2)
        {
            this.LeftTopPoint = point;
            this.RightBottomPoint = point2;
        }

        public override string ToString()
        {
            return $"[Rectagle => {this.LeftTopPoint}, {this.RightBottomPoint}, LengthVerticalSide ==> {this.LengthVerticalSide}, LengthHotizontalSide ==> {this.LengthHotizontalSide}]";
        }

        private double Perimetr()
        {
            return this.LengthVerticalSide + this.LengthHotizontalSide;
        }

        private double Min(double a, double b)
        {
            return a > b ? b : a;
        }

        private double Max(double a, double b)
        {
            return a > b ? a : b;
        }
    }
}
