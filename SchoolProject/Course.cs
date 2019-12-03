using Comparers.SchoolProject;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject
{
    public class Course
    {
        public string nameCourcse { get; set; }
        private readonly HashSet<Student> CourseStudents;

        public Course(string nameCourcse)
        {
            this.nameCourcse = nameCourcse;
            CourseStudents = new HashSet<Student>(new StudentComparer());
        }

        private Student joinCourse(Student student)
        {
            if (CourseStudents.Contains(student))
            {
                throw new ArgumentException("Student already registered in this course");
            }
            if(CourseStudents.Count >=29)
            {
                throw new ArgumentException("Course is full");
            }
            if (CourseStudents.Add(student))
            {
                return student;
            }
            throw new Exception("Something was wrong");
        }
        private Student leftCourse(Student student)
        {
            if (!CourseStudents.Contains(student))
            {
                throw new ArgumentException("Student is not registered in this course");
            }
            if (CourseStudents.Remove(student))
            {
                return student;
            }
            throw new Exception("Something was wrong");
        }
    }
}
