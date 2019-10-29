// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TestProjectForLoggers
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ShowerDirectory
    {
        public string ShowerDirectoryAndFiles(string path, StringBuilder stringbuilder)
        {
            try
            {

                DirectoryInfo directory = new DirectoryInfo(path);
                DirectoryInfo[] subDirectories = directory.GetDirectories();
                FileInfo[] files = directory.GetFiles();
                string searchPart = "width";
                Regex regex = new Regex(@"\w*" + searchPart + @"\w*", RegexOptions.IgnoreCase);
                //// Console.Write(FileWriter(files));

                stringbuilder.Append(this.FileWriter(files));

                ////Console.Write(SearchInString(FileWriter(files), searchPart));
                if (directory.GetDirectories().Length == 0)
                {

                }
                else
                {
                    foreach (DirectoryInfo dir in subDirectories)
                    {
                        ////Console.WriteLine("{0} ==> {1}", dir.FullName, dir);
                        stringbuilder.AppendLine($"{dir.FullName} ==> {dir}");
                        this.ShowerDirectoryAndFiles(dir.FullName, stringbuilder);
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
            foreach (string line in liness)
            {
                if (regex.IsMatch(line))
                {
                    stringbuilder.AppendLine($"We find your file in ==>{line.Replace("\r", "").Replace("\n", "")}");
                }
            }

            return stringbuilder.ToString();
        }
    }
}

//C:\Users\GOOD\source\repos\EpamTrainingSecond