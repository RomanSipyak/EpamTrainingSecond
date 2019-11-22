// <copyright file="MonthColection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Trainig1.Task3
{
    using System;

    public class MonthColection
    {
        public enum Month
        {
            January, February, March, April, May, June, July, August, September, October, November, December
        }

        public static string GetMonthByNumber(uint numberOfMonth)
        {
            try
            {
                if (numberOfMonth > 0 && numberOfMonth <= 12)
                {
                    return Enum.GetName(typeof(Month), numberOfMonth - 1);
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
