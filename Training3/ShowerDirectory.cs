﻿// <copyright file="ShowerDirectory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Training3
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ShowerDirectory : IOperations
    {
        public string ShowerDirectoryAndFiles(string path, StringBuilder stringbuilder)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                DirectoryInfo[] subDirectories = directory.GetDirectories();
                FileInfo[] files = directory.GetFiles();
                stringbuilder.Append(this.FileWriter(files));
                if (directory.GetDirectories().Length == 0)
                {
                }
                else
                {
                    foreach (DirectoryInfo dir in subDirectories)
                    {
                        stringbuilder.AppendLine($"{dir.FullName} ==> {dir}");
                        this.ShowerDirectoryAndFiles(dir.FullName, stringbuilder);
                    }
                }

                return stringbuilder.ToString();
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw e;
            }
            catch (ArgumentNullException e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string FileWriter(FileInfo[] filesinfo)
        {
            try
            {
                StringBuilder stringbuilder = new StringBuilder();
                foreach (FileInfo file in filesinfo)
                {
                    stringbuilder.AppendLine($"{file.DirectoryName} ==> {file}");
                }

                return stringbuilder.ToString();
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw e;
            }
            catch (ArgumentNullException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string SearchInString(string strings, string nameOfFile)
        {
            try
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
            catch (ArgumentOutOfRangeException e)
            {
                throw e;
            }
            catch (ArgumentNullException e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string SearchFileByRootPathAndPartName(string pathForDirectory, string nameOfFile)
        {
            try
            {
                return this.SearchInString(this.ShowerDirectoryAndFiles(pathForDirectory, new StringBuilder()), nameOfFile);
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw e;
            }
            catch (ArgumentNullException e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}