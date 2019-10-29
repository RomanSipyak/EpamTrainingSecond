namespace Trainig1.Task4
{
    using System;

    public enum Colors
    {
        Red = 4, Green = 115, Blue = 0, Grey = 33, Yellow = 15, Black = 2
    }

    public class Enum<T>
        where T : struct, IConvertible
    {
        public static System.Array SortedValues
        {
            get
            {
                if (!typeof(T).IsEnum)
                {
                    throw new ArgumentException("T must be an enumerated type");
                }

                Array values = Enum.GetValues(typeof(T));
                Array.Sort(values);
                return values;
            }
        }
    }
}
