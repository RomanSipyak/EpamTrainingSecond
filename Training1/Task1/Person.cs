using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainig1.Task1
{
    public struct Person
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public ushort YearOld { get; set; }
        
      
        public Person(string name, string SurName, ushort yearOld)
        {
            this.Name = name;
            this.SurName = SurName;
            this.YearOld = yearOld;
        }

        public string GetElder(ushort n)
        {
            return this.YearOld > n ? $"{Name} {SurName} older than {n}" :
                                 $"{Name} {SurName} younger than {n}";
        }
    }
}
