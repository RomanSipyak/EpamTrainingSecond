using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Tests
{
    [TestFixture]
    class Tests
    {
        [Test]
        public void AddCourseTest()
        {
            School school = new School();

            bool added = school.AddCourse("Math");
            Course addedCourse;
            school.AllCourses.TryGetValue(new Course("Math"), out addedCourse);


            Assert.IsTrue(added);
            Assert.AreEqual("Math", addedCourse.nameCourcse);
            Assert.AreEqual(1, school.AllCourses.Count);
        }
        [Test]
        public void AddCourseTestWithExistName()
        {
            School school = new School();

            bool added = school.AddCourse("Math");
            Course addedCourse;
            school.AllCourses.TryGetValue(new Course("Math"), out addedCourse);


            Assert.IsTrue(added);
            Assert.IsFalse(school.AddCourse("Math"));
            Assert.AreEqual(1, school.AllCourses.Count);
        }
        [Test]
        public void AddCourseTestWithMaxStudentsForCourse()
        {
            School school = new School();

            bool added = school.AddCourse("Math");
            Course addedCourse;
            school.AllCourses.TryGetValue(new Course("Math"), out addedCourse);
            for (int i = 0; i < 29; i++)
            {
                school.AddStudentToCourse(new Course("Math"), new Student(i, $"Student {30} "));
            }

            Assert.Throws<System.ArgumentException>(() => { school.AddStudentToCourse(new Course("Math"), new Student(30, "Student 30"));});
        }
    }
}
