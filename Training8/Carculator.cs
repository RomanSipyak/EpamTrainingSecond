// <copyright file="Carculator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Training8
{
    using System.Collections.Generic;

    public class Carculator
    {
        public delegate double FormulaRealization(double value1, double value2);

        public enum Operations
        {
            Plus,
            Minus,
            Divide,
            Multiply,
        }

        private Printer Printer;

        public Carculator(Printer printer)
        {
            this.Printer = printer;
        }

        public double SimpleOperations(Operations operation)
        {
            List<double> listValue = this.Printer.Read();
            double result;
            string stringResult;
            switch (operation)
            {
                case Operations.Divide:
                    {
                        result = listValue[0] / listValue[1];
                        stringResult = $"Result of operation {listValue[0]} / {listValue[1]} = {result}";
                        break;
                    }

                case Operations.Multiply:
                    {
                        result = listValue[0] * listValue[1];
                        stringResult = $"Result of operation {listValue[0]} * {listValue[1]} = {result}";
                        break;
                    }

                case Operations.Minus:
                    {
                        result = listValue[0] - listValue[1];
                        stringResult = $"Result of operation {listValue[0]} - {listValue[1]} = {result}";
                        break;
                    }

                case Operations.Plus:
                    {
                        result = listValue[0] + listValue[1];
                        stringResult = $"Result of operation {listValue[0]} + {listValue[1]} = {result}";
                        break;
                    }

                default:
                    {
                        result = double.NaN;
                        stringResult = $"Result of operation {listValue[0]} ? {listValue[1]} = {result}";
                        break;
                    }
            }

            this.Printer.Write(stringResult);
            return result;
        }

        //public double Multiply()
        //{
        //    List<double> listValue = Printer.Read();
        //    double result = listValue[0] * listValue[1];
        //    string stringResult = $"Result of operation {listValue[0]} * {listValue[1]} = {result}";
        //    Printer.Write(stringResult);
        //    return result;
        //}
        //public double Minus()
        //{
        //    List<double> listValue = Printer.Read();
        //    double result = listValue[0] - listValue[1];
        //    string stringResult = $"Result of operation {listValue[0]} - {listValue[1]} = {result}";
        //    Printer.Write(stringResult);
        //    return result;
        //}
        //public double Plus()
        //{
        //    List<double> listValue = Printer.Read();
        //    double result = listValue[0] + listValue[1];
        //    string stringResult = $"Result of operation {listValue[0]} + {listValue[1]} = {result}";
        //    Printer.Write(stringResult);
        //    return result;
        //}
        //public double Devide()
        //{
        //    List<double> listValue = Printer.Read();
        //    double result = listValue[0] / listValue[1];
        //    string stringResult = $"Result of operation {listValue[0]} / {listValue[1]} = {result}";
        //    Printer.Write(stringResult);
        //    return result;
        //}

        public double Formula(FormulaRealization realization)
        {
            List<double> listValue = this.Printer.Read();
            double result = realization(listValue[0], listValue[1]);
            string stringResult = $"Result of operation {listValue[0]} / {listValue[1]} = {result}";
            this.Printer.Write(stringResult);
            return result;
        }
    }
}