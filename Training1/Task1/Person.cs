// <copyright file="Person.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Trainig1.Task1
{
    using System;

    public struct Person
    {
        public Person(string name, string surName, ushort yearOld)
        {
            this.Name = name;
            this.SurName = surName;
            this.YearOld = yearOld;
        }

        public string Name { get; set; }

        public string SurName { get; set; }

        public ushort YearOld { get; set; }

        public string GetElder(ushort n)
        {
            try
            {
                return this.YearOld > n ? $"{this.Name} {this.SurName} older than {n}" :
                                                  $"{this.Name} {this.SurName} younger than {n}";
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
