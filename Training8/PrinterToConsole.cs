// <copyright file="PrinterToConsole.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Training8
{
    using System;
    using System.Collections.Generic;

    public class PrinterToConsole : Printer
    {
        public List<double> Read()
        {
            List<double> valuesOfOperation = new List<double>();
            Console.WriteLine("Write first value");
            double first = Convert.ToDouble(Console.ReadLine());
            valuesOfOperation.Add(first);
            Console.WriteLine("Write second value");
            double second = Convert.ToDouble(Console.ReadLine());
            valuesOfOperation.Add(second);
            return valuesOfOperation;
        }

        public void Write(string a)
        {
            Console.WriteLine(a);
        }
    }
}
