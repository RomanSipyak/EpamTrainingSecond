// <copyright file="Printer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Training8
{
    using System.Collections.Generic;

    public interface Printer
    {
        void Write(string a);

        List<double> Read();
    }
}
