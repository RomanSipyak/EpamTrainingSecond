// <copyright file="Man.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TestForDllLoader.ClassesForInstance
{
    public class Man
    {
        public Man(View view, IDoWork doWork, int age)
        {
            View = view;
            DoWork = doWork;
            Age = age;
        }

        public View View { get; set; }

        public IDoWork DoWork { get; set; }

        public int Age { get; set; }
    }
}
