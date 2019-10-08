using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTrainingSecond
{
    interface ISize
    {
         int Height { get; set; }
         int Width { get; set; }

         void Perimetr();
        
    }
}
