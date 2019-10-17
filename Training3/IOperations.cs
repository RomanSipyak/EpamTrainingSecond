using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training3
{
    public interface IOperations
    {
        string ShowerDirectoryAndFiles(string path, StringBuilder stringBuilder);

        string SearchInString(string strings, string nameOfFile);

        string SearchByRootPath(string pathForDirectory, string nameOfFile);
    }
}
