using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTrainingSecond
{
    public enum LongRange : Int64 { Max = 9223372036854775807, Min = -9223372036854775808 }
   
    public static class LongRangeTask
    {
        public static long OutputLongRange(LongRange name)
        {
            switch(name)
            {
                case LongRange.Max:
                {
                  return (Int64)(LongRange.Max);
                }
                case LongRange.Min:
                {
                  return (Int64)(LongRange.Min);
                }
                default:
                {
                  return default(Int64);
                }
            }
        }
    }
}
