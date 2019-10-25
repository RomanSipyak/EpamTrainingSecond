using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainig1.Task3
{
    public class MonthColection
    {
        enum Month
        {
            January, February, March, April, May, June, July, August, September, October, November, December
        }

        public static string GetMonthByNumber(uint numberOfMonth)
        {
            try
            {
                if (numberOfMonth > 0 && numberOfMonth <= 12)
                {
                    return Enum.GetName(typeof(Month), numberOfMonth - 2);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("numberOfMonth", "You write wrong number");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
