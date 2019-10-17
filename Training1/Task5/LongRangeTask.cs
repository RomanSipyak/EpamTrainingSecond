using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainig1.Task5
{
    public enum LongRange : long
    {
        Max = 9223372036854775807, Min = -9223372036854775808
    }

    public static class LongRangeTask
    {
        public static long OutputLongRange(LongRange name)
        {
            switch (name)
            {
                case LongRange.Max:
                    {
                        return (long)LongRange.Max;
                    }

                case LongRange.Min:
                    {
                        return (long)LongRange.Min;
                    }

                default:
                    {
                        return default(long);
                    }
            }
        }
    }
}
