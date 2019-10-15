using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Training3
{
    class ShowerDirectory
    {
        public static void ShowerDirectoryAndFiles(string path)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                DirectoryInfo directory = new DirectoryInfo(path);
                DirectoryInfo[] subDirectories = directory.GetDirectories();
                FileInfo[] files = directory.GetFiles();

                string searchPart = "with";
                Regex regex = new Regex(@"\w*"+ searchPart + @"\w*", RegexOptions.IgnoreCase);
                foreach (FileInfo file in files)
                {
                    if (regex.IsMatch(file.ToString()))
                    {
                        Console.WriteLine($"We find ==>{file}");
                    }
                    Console.WriteLine($"{file.DirectoryName} ==> {file}");
                }
                if (directory.GetDirectories().Length == 0)
                {
                }
                else
                {
                    foreach (DirectoryInfo dir in subDirectories)
                    {
                        Console.WriteLine("{0} ==> {1}", dir.FullName, dir);
                        ShowerDirectoryAndFiles(dir.FullName);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            
        }
    }
}
//C:\Users\GOOD\source\repos\EpamTrainingSecond