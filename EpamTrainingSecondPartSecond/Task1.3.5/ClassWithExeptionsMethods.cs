using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
namespace EpamTrainingSecondPartSecond.Task1._3._5
{
    public class ClassWithExeptionsMethods
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
        public static int GetNumber(int[] ArrayOfNumber, int index)
        {
            return ArrayOfNumber[index];
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