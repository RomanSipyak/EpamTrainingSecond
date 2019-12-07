// <copyright file="TreadSummarize.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Training9
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;

    public class TreadSummarize
    {
        public double Sum { get; private set; }

        private static readonly object Locker = new object();

        public double CalculateSum(double[,] array, int k)
        {
            List<double[,]> listWithSections = this.Separator(array, k);

            foreach (double[,] item in listWithSections)
            {
                Thread myThread = new Thread(new ParameterizedThreadStart(this.SumSection));
                myThread.Start(item);
                myThread.Join();
            }

            return this.Sum;
        }

        public void SumSection(object array)
        {
            Monitor.Enter(Locker);
            for (int i = 0; i < ((double[,])array).GetLength(0); i++)
            {
                for (int j = 0; j < ((double[,])array).GetLength(1); j++)
                {
                    Console.WriteLine($"Number of thread {Thread.CurrentThread.GetHashCode()} a[{i}][{j}] = {((double[,])array)[i, j]} sum = {Sum}");

                    this.Sum += ((double[,])array)[i, j];
                    Console.WriteLine($"Number of thread {Thread.CurrentThread.GetHashCode()} sum = {Sum}");
                }
            }

            Monitor.Exit(Locker);
        }

        public List<double[,]> Separator(double[,] array, int k)
        {
            int row = array.GetLength(0);
            int column = array.GetLength(1);
            int devision = row / k;
            int lengthOfList = 0;
            double[,] separateArray;

            if (column / k > 0)
            {
                lengthOfList = k;
            }

            if (column / k == 0)
            {
                lengthOfList = column;
                k = column;
            }

            List<double[,]> listOfSeparateValues = new List<double[,]>();
            int j = 0;
            int m = 0;
            for (int i = 1; i <= lengthOfList; i++)
            {
                //if (i == 3) Debugger.Break();
                if (i != lengthOfList || column % k == 0)
                {
                    separateArray = new double[row, column / k];
                }
                else
                {
                    separateArray = new double[row, column - ((i - 1) * column / k)];
                }

                m = j;
                for (int r = 0; r < row; r++)
                {
                    j = m;
                    int collum2 = 0;
                    if (i != lengthOfList)
                    {
                        while (j < i * (column / k))
                        {
                            separateArray[r, collum2] = array[r, j];
                            j++;
                            collum2++;
                        }
                    }
                    else
                    {
                        while (j < column)
                        {
                            separateArray[r, collum2] = array[r, j];
                            j++;
                            collum2++;
                        }
                    }
                }

                listOfSeparateValues.Add(separateArray);
            }

            return listOfSeparateValues;
        }
    }
}
