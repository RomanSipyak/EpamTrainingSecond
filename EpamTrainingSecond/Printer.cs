using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTrainingSecond
{
    class Printer : ShowInterface
    {
        public void Show()
        {
            Person person = new Person("Roma", "Sypiak", 21);
            Console.WriteLine(person.GetElder(15));
            Console.WriteLine(person.GetElder(21));
            uint n = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine(MonthWriter.GetMonthByNumber(n));
            foreach (var value in Enum<Colors>.SortedValues)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine("Min = > {0}", LongRangeTask.OutputLongRange(LongRange.Min));
            Console.WriteLine("Max = > {0}", LongRangeTask.OutputLongRange(LongRange.Max));
            Console.ReadKey();
        }
    }
}
