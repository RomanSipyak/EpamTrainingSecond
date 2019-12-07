namespace SchoolProject
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using SchoolProject.Comparers;

    public class School
    {
        private readonly HashSet<Student> allStudents;

        private readonly HashSet<Course> allCourses;

        public School()
        {
            this.allStudents = new HashSet<Student>(new StudentComparerById());
            this.allCourses = new HashSet<Course>(new CourseComparer());
        }

        public bool AddCourse(string name)
        {
            return this.allCourses.Add(new Course(name));
        }

        public bool AddStudentToSchool(Student student)
        {
            Student taketStudent;
            this.allStudents.TryGetValue(student, out taketStudent);
            if (taketStudent != null)
            {
                throw new ArgumentException("Student with the same id already exist");
            }

            if (student.Number < 10000 || student.Number > 99999)
            {
                throw new ArgumentException("Wrong id");
            }

            if (student.Name == null || student.Name.Trim().Equals(""))
            {
                throw new ArgumentException("Wrong name, can`t be empty");
            }
            else
            {
                return this.allStudents.Add(student);
            }
        }

        public bool AddStudentToCourse(Course course, Student student)
        {
            try
            {
                this.AddStudentToSchool(student);
            }
            catch (ArgumentException e)
            {
                if (!e.Message.Equals("Student with the same id already exist"))
                {
                    throw e;
                }
            }

            Course responseCourse;
            this.allCourses.TryGetValue(course, out responseCourse);
            if (responseCourse == null)
            {
                throw new ArgumentException("Course don`t exist");
            }

            try
            {
                Student addedStudent = (Student)responseCourse.GetType().InvokeMember(
                    "JoinToCourse",
                    BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod,
                    null,
                    responseCourse,
                    new object[] { student });
                return addedStudent != null;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public bool RemoveStudentFromCourse(Course course, Student student)
        {
            Course responseCourse;
            this.allCourses.TryGetValue(course, out responseCourse);
            if (responseCourse == null)
            {
                throw new ArgumentException("Course don`t exist");
            }

            try
            {
                Student removedSrudent = (Student)responseCourse.GetType().InvokeMember(
                    "LeaveCourse",
                    BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod,
                    null,
                    responseCourse,
                    new object[] { student });
                return removedSrudent != null;
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        public bool RemoveStudentFromSchool(Student student)
        {
            int deletedCounter = 0;
            Student studentForDelete;
            this.allStudents.TryGetValue(student, out studentForDelete);
            if (studentForDelete == null)
            {
                throw new ArgumentException("Your student don`t study in this school");
            }
            else
            {
                this.allStudents.Remove(student);
                foreach (Course course in this.allCourses)
                {
                    try
                    {
                        Student removedSrudent = (Student)course.GetType().InvokeMember(
                            "LeaveCourse",
                            BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod,
                            null,
                            course,
                            new object[] { student });
                        if (removedSrudent != null)
                        {
                            deletedCounter++;
                        }
                    }
                    catch (Exception e)
                    {
                        if (e.InnerException.Message.Equals("Something was wrong"))
                        {
                            throw e;
                        }
                    }
                }
            }

            return deletedCounter > 0 ? true : false;
        }

        public Course TryGetValueFromAllCourses(Course course)
        {
            Course returnCourse;
            this.allCourses.TryGetValue(course, out returnCourse);
            return returnCourse;
        }

        public int CoutnOfCourses()
        {
            return this.allCourses.Count;
        }

        public Student TryGetValueFromAllStudents(Student student)
        {
            Student returnStudent;
            this.allStudents.TryGetValue(student, out returnStudent);
            return returnStudent;
        }

        public int CoutnOfStudents()
        {
            return this.allStudents.Count;
        }
    }
}
