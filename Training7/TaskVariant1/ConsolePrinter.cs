namespace Training7.TaskVariant1
{
    using System;
    using System.Collections.Generic;

    public class ConsolePrinter : IWriter
    {
        public void Print(List<string> list)
        {
            try
            {
                Console.WriteLine("Unique elements {0}", list.Count);
                foreach (string value in list)
                {
                    Console.WriteLine(value);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
