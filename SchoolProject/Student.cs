using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject
{
    public class Student
    {
        public int Number { get; set; }

        public string Name { get; set; }
        public Student(int number, string name)
        {
            Number = number;
            Name = name;
        }
    }
   
}
