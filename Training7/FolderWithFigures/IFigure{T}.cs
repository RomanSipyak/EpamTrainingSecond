// <copyright file="IFigure{T}.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Training7.FolderWithFigures
{
    public interface IFigure<T>
    {
        T Least(T figure2);

        T Biggest(T figure2);

        void Move(double moveByX, double moveByY);

        void ChangeSize(Point point, Point point2);
    }
}
