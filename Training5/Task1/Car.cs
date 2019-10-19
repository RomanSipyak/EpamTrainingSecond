using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training5.Task1
{
    [Serializable]
    public class Car
    {
        public string Marck { get; set; }

        public int Speed { get; set; }
        
       public override string ToString()
        {
            return $"Mark => {Marck} Speed=> {Speed}";
        }
    }
}
