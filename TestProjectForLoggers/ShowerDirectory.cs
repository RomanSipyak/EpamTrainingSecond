using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestProjectForLoggers
{
    class ShowerDirectory
    {
        public string ShowerDirectoryAndFiles(string path, StringBuilder stringbuilder)
        {
            try
            {
               
                DirectoryInfo directory = new DirectoryInfo(path);
                DirectoryInfo[] subDirectories = directory.GetDirectories();
                FileInfo[] files = directory.GetFiles();
                string searchPart = "width";
                Regex regex = new Regex(@"\w*"+ searchPart + @"\w*", RegexOptions.IgnoreCase);
                //Console.Write(FileWriter(files));
                stringbuilder.Append(FileWriter(files));
                //Console.Write(SearchInString(FileWriter(files), searchPart));
                if (directory.GetDirectories().Length == 0)
                {
                   
                }
                else
                {
                    foreach (DirectoryInfo dir in subDirectories)
                    {
                        //Console.WriteLine("{0} ==> {1}", dir.FullName, dir);
                        stringbuilder.AppendLine($"{dir.FullName} ==> {dir}");
                        ShowerDirectoryAndFiles(dir.FullName,stringbuilder);
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
                    stringbuilder.AppendLine($"We find your file in ==>{line.Replace("\r","").Replace("\n","")}");
                }
            }
            return stringbuilder.ToString();
        }
    }
}
//C:\Users\GOOD\source\repos\EpamTrainingSecond