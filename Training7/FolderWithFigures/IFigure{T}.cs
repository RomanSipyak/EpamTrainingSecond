using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training7.FolderWithFigures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IFigure<T>
    {
        T Least(T figure2);

        T Biggest(T figure2);

        void Move(double moveByX, double moveByY);

        void ChangeSize(Point point, Point point2);
    }
}
