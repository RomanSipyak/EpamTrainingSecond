using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTrainingSecondPartSecond.Task1._3._5;

namespace EpamTrainingSecondPartSecond
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ClassWithExeptionsMethods.FibonachiWithExeption(5);
            }
            catch (StackOverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                ClassWithExeptionsMethods.GetNumber(new int[] { 1, 2, 3 }, 5);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                ClassWithExeptionsMethods.DoSomeMath(-2, 10);
            }
            catch (ArgumentException e)
            when (e.ParamName == "a")
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            when (e.ParamName == "b")
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                ClassWithExeptionsMethods.DoSomeMath(5, 10);
            }
            catch (ArgumentException e)
            when (e.ParamName == "a")
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            when (e.ParamName == "b")
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
