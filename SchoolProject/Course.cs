namespace SchoolProject
{
    using System;
    using System.Collections.Generic;
    using SchoolProject.Comparers;

    public class Course
    {
        private readonly HashSet<Student> courseStudents;

        public Course(string nameCourcse)
        {
            this.NameCourcse = nameCourcse;
            courseStudents = new HashSet<Student>(new StudentComparerById());
        }

        public string NameCourcse { get; set; }

        public Student GetStudent(Student student)
        {
            Student studentForReturn;
            this.courseStudents.TryGetValue(student, out studentForReturn);
            return studentForReturn;
        }

        public int GetStudentsCount()
        {
            return this.courseStudents.Count;
        }

        private Student JoinToCourse(Student student)
        {
            if (this.courseStudents.Contains(student))
            {
                throw new ArgumentException("Student already registered in this course");
            }

            if (this.courseStudents.Count >= 29)
            {
                throw new ArgumentException("Course is full");
            }

            if (this.courseStudents.Add(student))
            {
                return student;
            }

            throw new Exception("Something was wrong");
        }

        private Student LeaveCourse(Student student)
        {
            if (!this.courseStudents.Contains(student))
            {
                throw new ArgumentException("Student is not registered in this course");
            }

            if (this.courseStudents.Remove(student))
            {
                return student;
            }

            throw new Exception("Something was wrong");
        }
    }
}
