using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Training2.Task1._3._5
{
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
        public static int GetNumber(int[] ArrayOfNumber, int index)
        {
            try
            {
                return ArrayOfNumber[index];
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
