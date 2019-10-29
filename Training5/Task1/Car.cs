// <copyright file="Car.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Training5.Task1
{
    using System;

    [Serializable]
    public class Car
    {
        public string Marck { get; set; }

        public int Speed { get; set; }

        public override string ToString()
        {
            return $"Mark => {Marck} Speed=> {Speed}";
        }
    }
}
