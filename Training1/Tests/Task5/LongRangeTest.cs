// <copyright file="LongRangeTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Training1.Tests.Task5
{
    using NUnit.Framework;
    using Trainig1.Task5;

    [TestFixture]
    public class LongRangeTest
    {
        [TestCase(LongRange.Max, ExpectedResult = 9223372036854775807)]
        [TestCase(LongRange.Min, ExpectedResult = -9223372036854775808)]
        public double LongRangeTaskTest(LongRange parameter)
        {
            return LongRangeTask.OutputLongRange(parameter);
        }
    }
}
