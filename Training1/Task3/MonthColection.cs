using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainig1.Task3
{
    public class MonthColection
    {
        enum Month { January, February, March, April, May, June, July, August, September, October, November, December }

        public static string GetMonthByNumber(uint NumberOfMonth)
        {
            if (NumberOfMonth >= 0 && NumberOfMonth <= 12)
            {
                return Enum.GetName(typeof(Month), NumberOfMonth - 1);
            }
            return "";
        }
    }
}
