// <copyright file="PersonTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Training1.Tests.Task1
{
    using NUnit.Framework;
    using Trainig1.Task1;

    [TestFixture]
    public class PersonTest
    {
        [TestCase((ushort)1, ExpectedResult = "testName testSurname older than 1")]
        [TestCase((ushort)15, ExpectedResult = "testName testSurname younger than 15")]
        public string GetElderTest(ushort n)
        {
            var testPerson = new Person("testName", "testSurname", 12);
            return testPerson.GetElder(n);
        }
    }

}
