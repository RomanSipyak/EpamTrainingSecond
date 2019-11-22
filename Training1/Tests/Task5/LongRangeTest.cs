using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainig1.Task5;

namespace Training1.Tests.Task5
{
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
