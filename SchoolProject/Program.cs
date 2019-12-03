using System;

namespace SchoolProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Course cource;
            School school = new School();
            school.AddCourse("mathematic");
            school.AddStudentToCourse(new Course("mathematic"), new Student(10001, "jojo"));
            school.AllCourses.TryGetValue(new Course("mathematic"), out cource);
            school.AddStudentToCourse(new Course("mathematic"), new Student(10002, "jojo1"));
            school.AllCourses.TryGetValue(new Course("mathematic"), out cource);
            school.RemoveStudentToCourse(new Course("mathematic"), new Student(10001, "jojo"));
            school.RemoveStudentToCourse(new Course("mathematic"), new Student(10002, "jojo1"));
            school.AllCourses.TryGetValue(new Course("mathematic"), out cource);
            Console.ReadKey();
        }
    }
}
