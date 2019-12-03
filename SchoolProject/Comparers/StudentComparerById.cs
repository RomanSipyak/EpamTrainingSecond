using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Comparers
{
    class StudentComparerById : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            if (x.Number == x.Number)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(Student obj)
        {
            int hash = 17;
            hash = hash * 23 + obj.Number.GetHashCode();
            return hash;
        }
    }
}
