// <copyright file="Student.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SchoolProject
{
    public class Student
    {
        public int Number { get; set; }

        public string Name { get; set; }

        public Student(int number, string name)
        {
            this.Number = number;
            this.Name = name;
        }
    }
}
