using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Training3
{
    public class ShowerDirectory
    {
        public string ShowerDirectoryAndFiles(string path, StringBuilder stringbuilder)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                DirectoryInfo[] subDirectories = directory.GetDirectories();
                FileInfo[] files = directory.GetFiles();
                stringbuilder.Append(FileWriter(files));
                if (directory.GetDirectories().Length == 0)
                {
                }
                else
                {
                    foreach (DirectoryInfo dir in subDirectories)
                    {
                        stringbuilder.AppendLine($"{dir.FullName} ==> {dir}");
                        ShowerDirectoryAndFiles(dir.FullName, stringbuilder);
                    }
                }
                return stringbuilder.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public string FileWriter(FileInfo[] filesinfo)
        {   
            StringBuilder stringbuilder = new StringBuilder();
            foreach (FileInfo file in filesinfo)
            {
                stringbuilder.AppendLine($"{file.DirectoryName} ==> {file}");
            }
            return stringbuilder.ToString();
        }
        public string SearchInString(String strings, String nameOfFile)
        {
            StringBuilder stringbuilder = new StringBuilder();
            string[] liness = Regex.Split(strings, "\r\n");
            Regex regex = new Regex(@"\w*" + nameOfFile + @"\w*", RegexOptions.IgnoreCase);
            foreach (String line in liness)
            {
                if (regex.IsMatch(line))
                {
                    stringbuilder.AppendLine($"We find your file in ==>{line.Replace("\r", "").Replace("\n", "")}");
                }
            }
            return stringbuilder.ToString();
        }
        public string SearchByRootPath(String PathForDirectory, String nameOfFile)
        {
            return SearchInString(ShowerDirectoryAndFiles(PathForDirectory, new StringBuilder()), nameOfFile);
        }
    }
}
//C:\Users\GOOD\source\repos\EpamTrainingSecond