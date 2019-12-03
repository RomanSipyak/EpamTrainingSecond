using SchoolProject.Comparers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SchoolProject
{
    public class School
    {
        public readonly HashSet<Student> AllStudents;

        public readonly HashSet<Course> AllCourses;

        public School()
        {
            AllStudents = new HashSet<Student>(new StudentComparerById());
            AllCourses = new HashSet<Course>(new CourseComparer());
        }

        public bool AddCourse(string Name)
        {
            return AllCourses.Add(new Course(Name));
        }

        public bool AddUserToCourse(Student student, String courseName)
        {
            Course course = new Course(courseName);
            Course responseCourse;
            AllCourses.TryGetValue(course, out responseCourse);
            if (course != null)
            {
                throw new ArgumentException("Course already exist");
            }
            else
            {
                return AllCourses.Add(course);
            }
        }

        public bool AddStudentToSchoot(Student student)
        {
            Student taketStudent;
            AllStudents.TryGetValue(student, out taketStudent);
            if (taketStudent != null)
            {
                throw new ArgumentException("Student with the same id already exist");
            }

            if (student.Number < 10000 || student.Number > 99999 || student.Name == null || student.Name.Trim().Equals(""))
            {
                throw new ArgumentException("Wrong id");
            }

            if (student.Name == null || student.Name.Trim().Equals(""))
            {
                throw new ArgumentException("Wrong can`t be empty");
            }

            else
            {
                return AllStudents.Add(student);
            }
        }

        public bool AddStudentToCourse(Course course, Student student)
        {
            Course responseCourse;
            AllCourses.TryGetValue(course, out responseCourse);
            if (responseCourse == null)
            {
                throw new ArgumentException("Course don`t exist");
            }
            try
            {
                Student addedStudent = (Student)responseCourse.GetType().InvokeMember("joinCourse",
                BindingFlags.DeclaredOnly |
                BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.InvokeMethod, null, responseCourse, new object[] { student });
                return addedStudent != null;
            }
            catch(ArgumentException e)
            {
                throw e;
            }
            
        }
        public bool RemoveStudentToCourse(Course course, Student student)
        {
            Course responseCourse;
            AllCourses.TryGetValue(course, out responseCourse);
            if (responseCourse == null)
            {
                throw new ArgumentException("Course don`t exist");
            }
            try
            {
                Student removedSrudent = (Student)responseCourse.GetType().InvokeMember("leftCourse",
                BindingFlags.DeclaredOnly |
                BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.InvokeMethod, null, responseCourse, new object[] { student });
                return removedSrudent != null;
            }
            catch(ArgumentException e)
            {
                throw e;
            }
        }
    }
}
