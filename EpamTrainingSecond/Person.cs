using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTrainingSecond
{
    public struct Person
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public ushort YearOld { get; set; }

        public Person(string Name, string SurName, ushort YearOld)
        {
            this.Name = Name;
            this.SurName = SurName;
            this.YearOld = YearOld;
        }

        public string GetElder(ushort n)
        {
            return YearOld > n ? $"{Name} {SurName} older than {n}" :
                                 $"{Name} {SurName} younger than {n}";
        }


    }
}
