//using Comparers.SchoolProject;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace SchoolProject.Tests
//{
//    [TestFixture]
//    public class TestsForSchool
//    {
//        [Test]
//        public void AddCourse()
//        {
//            School school = new School();

//            bool added = school.AddCourse("Math");

//            Course addedCourse = school.TryGetValueFromAllCourses(new Course("Math"));


//            Assert.IsTrue(added);
//            Assert.AreEqual("Math", addedCourse.NameCourcse);
//            Assert.AreEqual(1, school.CoutnOfCourses());
//        }

//        [Test]
//        public void AddCourseTestWithExistName()
//        {
//            School school = new School();

//            bool added = school.AddCourse("Math");

//            Course addedCourse = school.TryGetValueFromAllCourses(new Course("Math"));


//            Assert.IsTrue(added);
//            Assert.IsFalse(school.AddCourse("Math"));
//            Assert.AreEqual(1, school.CoutnOfCourses());
//        }
//        [Test]
//        public void AddCourseTestWithMaxStudentsForCourse()
//        {
//            School school = new School();

//            bool added = school.AddCourse("Math");

//            Course addedCourse = school.TryGetValueFromAllCourses(new Course("Math"));
//            for (int i = 0; i < 29; i++)
//            {
//                school.AddStudentToCourse(new Course("Math"), new Student(i + 10000, $"Student {30} "));
//            }

//            Assert.Throws<System.ArgumentException>(() => { school.AddStudentToCourse(new Course("Math"), new Student(20000, "Student 30")); });
//        }
//        [Test]
//        public void AddStudenttWithInvalidName()
//        {
//            School school = new School();

//            Assert.Throws<System.ArgumentException>(() => { school.AddStudentToSchool(new Student(1, "     ")); });
//        }

//        [TestCase(1, ExpectedResult = "Wrong id")]
//        [TestCase(100000, ExpectedResult = "Wrong id")]
//        public string AddStudenttWithInvalidId(int id)
//        {
//            School school = new School();
//            try
//            {
//                school.AddStudentToSchool(new Student(id, "   roma  "));
//            }
//            catch (ArgumentException e)
//            {
//                return e.Message;
//            }
//            return "";
//        }

//        [Test]
//        public void AddStudenttWithSameIdToSchool()
//        {
//            School school = new School();

//            school.AddStudentToSchool(new Student(10001, "   roma  "));

//            Assert.Throws<ArgumentException>(() => { school.AddStudentToSchool(new Student(10001, "   roma  ")); });

//        }

//        [Test]
//        public void AddStudentForCourseThetStudentAreNotInSchhol()
//        {
//            School school = new School();
//            school.AddCourse("Math");
//            school.AddStudentToCourse(new Course("Math"), new Student(10001, "   roma  "));


//            Course course = school.TryGetValueFromAllCourses(new Course("Math"));

//            Student sudentInCourse = course.GetStudent(new Student(10001, "   roma  "));
//            Student sudentInSchool = school.TryGetValueFromAllStudents(new Student(10001, "   roma  "));

//            Assert.That(new Student(10001, "   roma  "), Is.EqualTo(sudentInCourse).Using(new StudentComparer()));
//            Assert.That(new Student(10001, "   roma  "), Is.EqualTo(sudentInCourse).Using(new StudentComparer()));

//        }
//        [Test]
//        public void AddStudentForCourseThetStudentInInSchhol()
//        {
//            School school = new School();
//            school.AddCourse("Math");
//            school.AddStudentToSchool(new Student(10001, "   roma  "));
//            school.AddStudentToCourse(new Course("Math"), new Student(10001, "   roma  "));


//            Course course = school.TryGetValueFromAllCourses(new Course("Math"));

//            Student sudentInCourse = course.GetStudent(new Student(10001, "   roma  "));
//            Student sudentInSchool = school.TryGetValueFromAllStudents(new Student(10001, "   roma  "));

//            Assert.That(new Student(10001, "   roma  "), Is.EqualTo(sudentInCourse).Using(new StudentComparer()));
//            Assert.That(new Student(10001, "   roma  "), Is.EqualTo(sudentInCourse).Using(new StudentComparer()));

//        }
//    }
//}
