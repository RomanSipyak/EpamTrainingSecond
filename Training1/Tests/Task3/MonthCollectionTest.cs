namespace Training1.Tests.Task3
{
    using System;
    using NUnit.Framework;
    using Trainig1.Task3;

    [TestFixture]
    class MonthCollectionTest
    {
        [TestCase(1U, ExpectedResult = "January")]
        [TestCase(12U, ExpectedResult = "December")]
        public string GetMonthByNumbeTest(uint a)
        {
            return MonthColection.GetMonthByNumber(a);
        }

        [TestCase(0U)]
        [TestCase(14U)]
        public void GetMonthByNumberExceptionTest(uint a)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => MonthColection.GetMonthByNumber(a));
        }
    }
}
