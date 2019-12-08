// <copyright file="View.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TestForDllLoader.ClassesForInstance
{
    public class View
    {
        public View(int weight, int height)
        {
            this.Weight = weight;
            this.Height = height;
        }

        public int Weight { get; set; }

        public int Height { get; set; }
    }
}