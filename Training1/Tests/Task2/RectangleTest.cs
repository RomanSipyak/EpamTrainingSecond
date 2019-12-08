// <copyright file="RectangleTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Training1.Tests.Task2
{
    using System;
    using NUnit.Framework;
    using Trainig1.Task2;

    [TestFixture]
    public class RectangleTest
    {
        [TestCase(1, 2, ExpectedResult = 6)]
        [TestCase(3, 4, ExpectedResult = 14)]
        public double GetPerimetrTest(int a, int b)
        {
            var testRectangle = new Rectangle(a, b, 0, 0);
            return testRectangle.Perimetr();
        }

        [Test]
        public void GetPerimetrArgumentTest()
        {
            var testRectangle = new Rectangle(0, 1, 0, 0);
            Assert.Throws<ArgumentException>(() => testRectangle.Perimetr());
        }
    }
}
