// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TestForDllLoader
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dllclass;
    using TestForDllLoader.ClassesForInstance;

    class Program
    {
        static void Main(string[] args)
        {
            DynamicDllInstancesLoader creater = new DynamicDllInstancesLoader();
            List<Man> instanceOfMan = creater.LoadInstances<Man>();
            Console.WriteLine($"{ instanceOfMan.Count()}");
        }
    }
}
