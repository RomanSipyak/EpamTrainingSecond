// <copyright file="LongRangeTask.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Trainig1.Task5
{
    public enum LongRange : long
    {
        Max = 9223372036854775807,
        Min = -9223372036854775808,
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
