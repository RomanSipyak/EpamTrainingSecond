namespace SchoolProject.Comparers
{
    using System.Collections.Generic;

    public class CourseComparer : IEqualityComparer<Course>
    {
        public bool Equals(Course x, Course y)
        {
            if (x.NameCourcse.Equals(y.NameCourcse))
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
                hash = (hash * 23) + obj.NameCourcse.GetHashCode();
                return hash;
            }
        }
    }
}
