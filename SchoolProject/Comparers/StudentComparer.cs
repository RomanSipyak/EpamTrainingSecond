﻿// <copyright file="StudentComparer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SchoolProject.Comparers
{
    using System.Collections.Generic;

    class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            if (x.Name.Equals(y.Name))
            {
                if (x.Number == x.Number)
                {
                    return true;
                }
            }

            return false;
        }

        public int GetHashCode(Student obj)
        {
            int hash = 17;
            hash = (hash * 23) + obj.Name.GetHashCode();
            hash += (hash * 23) + obj.Number.GetHashCode();
            return hash;
        }
    }
}
