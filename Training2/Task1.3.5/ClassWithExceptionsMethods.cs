// <copyright file="ClassWithExceptionsMethods.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Training2.Task1._3._5
{
    using System;
    using System.Runtime.CompilerServices;

    public class ClassWithExceptionsMethods
    {
        public static int FibonachiWithExeption(int number)
        {
            try
            {
                RuntimeHelpers.EnsureSufficientExecutionStack();
                return number * FibonachiWithExeption(number - 1);
            }
            catch (InsufficientExecutionStackException)
            {
                throw new StackOverflowException();
            }
        }

        public static int GetNumber(int[] arrayOfNumber, int index)
        {
            try
            {
                return arrayOfNumber[index];
            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void DoSomeMath(int a, int b)
        {
            if (a < 0)
            {
                throw new ArgumentException("Parameter should be greater than 0", "a");
            }

            if (b > 0)
            {
                throw new ArgumentException("Parameter should be less than 0", "b");
            }
        }
    }
}
