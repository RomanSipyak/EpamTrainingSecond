// <copyright file="IPrinter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PrinterHelpers.PrintersImplementations
{
    using System;

    public class ConsolePrinter : IPrinter
    {
        public void Writeline(string str)
        {
            Console.WriteLine(str);
        }

        public void Write(string str)
        {
            Console.Write(str);
        }
    }
}
