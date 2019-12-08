// <copyright file="Circle.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Training7.FolderWithFigures
{
    using System;
    using System.Collections.Generic;

    public class Cirlce : IFigure<Cirlce>
    {
        public Cirlce(Point center, Point pointOnBoard)
        {
            this.Center = center;
            this.PointOnBoard = pointOnBoard;
            this.Radius = VectorOperations.CalcLenghtVector(center, pointOnBoard);
        }

        private Point center;
        private Point pointOnBoard;

        public Point Center
        {
            get
            {
                return this.center;
            }

            set
            {
                center = value;
                if (this.PointOnBoard != null)
                {
                    this.Radius = VectorOperations.CalcLenghtVector(this.center, this.PointOnBoard);
                }
            }
        }

        public Point PointOnBoard
        {
            get
            {
                return this.pointOnBoard;
            }

            set
            {
                pointOnBoard = value;
                if (this.Center != null)
                {
                    this.Radius = VectorOperations.CalcLenghtVector(this.Center, this.pointOnBoard);
                }
            }
        }

        public double Radius { get; private set; }

        public static bool operator <(Cirlce cirlce, Cirlce cirlce2)
        {
            return cirlce.Radius < cirlce2.Radius ? true : false;
        }

        public static bool operator >(Cirlce cirlce, Cirlce cirlce2)
        {
            return cirlce.Radius > cirlce2.Radius ? true : false;
        }

        public List<Point> Intersection(Cirlce cirlse2)
        {
            double distance = VectorOperations.CalcLenghtVector(this.Center, cirlse2.Center);
            if (this.Radius + cirlse2.Radius < distance || this.Abs(this.Radius + cirlse2.Radius) > distance)
            {
                return null;
            }
            else
            {
                double catetFirstCircle = ((this.Radius * this.Radius) - (cirlse2.Radius * cirlse2.Radius) + (distance * distance)) / (2 * distance);
                double hight = Math.Sqrt((this.Radius * this.Radius) - (catetFirstCircle * catetFirstCircle));
                double intersectionpointX = this.Center.X + (catetFirstCircle * (cirlse2.Center.X - this.Center.X) / distance);
                double intersectionpointY = this.Center.Y + (catetFirstCircle * (cirlse2.Center.Y - this.Center.Y) / distance);
                Point pointForIntersection = new Point(intersectionpointX, intersectionpointY);

                intersectionpointX = pointForIntersection.X + (hight * (cirlse2.Center.Y - this.Center.Y) / distance);
                intersectionpointY = pointForIntersection.Y - (hight * (cirlse2.Center.X - this.Center.X) / distance);

                Point firstResaultPoint = new Point(intersectionpointX, intersectionpointY);

                intersectionpointX = pointForIntersection.X - (hight * (cirlse2.Center.Y - this.Center.Y) / distance);
                intersectionpointY = pointForIntersection.Y + (hight * (cirlse2.Center.X - this.Center.X) / distance);

                Point secondResaultPoint = new Point(intersectionpointX, intersectionpointY);

                return new List<Point> { firstResaultPoint, secondResaultPoint };
            }
        }

        public Cirlce Least(Cirlce cirlce2)
        {
            return this > cirlce2 ? cirlce2 : this;
        }

        public Cirlce Biggest(Cirlce cirlce2)
        {
            return this < cirlce2 ? cirlce2 : this;
        }

        public void Move(double moveByX, double moveByY)
        {
            this.Center = new Point(this.Center.X + moveByX, this.Center.Y + moveByY);
            this.PointOnBoard = new Point(this.PointOnBoard.X + moveByX, this.PointOnBoard.Y + moveByY);
        }

        public void ChangeSize(Point point, Point point2)
        {
            this.Center = point;
            this.PointOnBoard = point2;
            this.Radius = VectorOperations.CalcLenghtVector(point, point2);
        }

        public override string ToString()
        {
            return $"Center => ({this.Center.X},{this.Center.Y}),PointOnBoard => ({this.PointOnBoard.X},{this.PointOnBoard.Y}),Radius ==>({this.Radius}))"; ;
        }

        private double Abs(double absValue)
        {
            return absValue > 0 ? -absValue : absValue;
        }
    }
}
