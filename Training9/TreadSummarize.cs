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
        public double sum = 0;
        private static readonly object locker = new object();

        public double CalculateSum(double[,] array, int k)
        {
            List<double[,]> listWithSections = this.Separator(array, k);

            foreach (double[,] item in listWithSections)
            {
                Thread myThread = new Thread(new ParameterizedThreadStart(this.SumSection));
                myThread.Start(item);
                myThread.Join();
            }

            return sum;
        }

        public void SumSection(object array)
        {

            Monitor.Enter(locker);
            for (int i = 0; i < ((double[,])array).GetLength(0); i++)
            {
                for (int j = 0; j < ((double[,])array).GetLength(1); j++)
                {
                    Console.WriteLine($"Number of thread {Thread.CurrentThread.GetHashCode()} a[{i}][{j}] = {((double[,])array)[i, j]} sum = {sum}");

                    sum += ((double[,])array)[i, j];
                    Console.WriteLine($"Number of thread {Thread.CurrentThread.GetHashCode()} sum = {sum}");
                }
            }

            Monitor.Exit(locker);
        }

        public List<double[,]> Separator(double[,] array, int k)
        {
            int row = array.GetLength(0);
            int column = array.GetLength(1);
            int devision = row / k;
            int lengthOfList = k;
            double[,] separateArray;
            if (row % k != 0)
            {
                lengthOfList++;
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
                    separateArray = new double[row, array.GetLength(1) - ((column / k) * k)];
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
                            //Console.Write(array[r, j]);
                            separateArray[r, collum2] = array[r, j];
                            j++;
                            collum2++;
                        }
                    }
                    else
                    {
                        while (j < column)
                        {
                            //Console.Write(array[r, j]);
                            separateArray[r, collum2] = array[r, j];
                            j++;
                            collum2++;
                        }
                    }
                }

                listOfSeparateValues.Add(separateArray);
                Console.WriteLine();
            }

            return listOfSeparateValues;
        }
    }
}
