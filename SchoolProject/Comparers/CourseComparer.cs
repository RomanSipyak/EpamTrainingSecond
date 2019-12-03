using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Comparers
{
    class CourseComparer : IEqualityComparer<Course>
    {
        public bool Equals(Course x, Course y)
        {
            if (x.nameCourcse.Equals(y.nameCourcse))
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(Course obj)
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + obj.nameCourcse.GetHashCode();
                return hash;
            }
        }
    }
}
