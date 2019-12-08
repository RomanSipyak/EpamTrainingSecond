// <copyright file="ShowerDirectory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Training7.FolderTaskVariant2
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;

    public class ShowerDirectory
    {
        public delegate void Output();

        private Output outputMethods;

        public Output OutputMethods
        {
            get
            {
                return outputMethods;
            }

            set
            {
                outputMethods += value;
            }
        }

        public HashSet<FileInfo> DirectoryInfo1 { get; private set; }

        public HashSet<FileInfo> DirectoryInfo2 { get; private set; }

        public ShowerDirectory()
        {
            string[] infoAboutFirstFoder = ShowerDirectory.ShowAllFiles(ConfigurationManager.AppSettings["PathFolderFirst"].ToString());
            this.DirectoryInfo2 = new HashSet<FileInfo>();

            string[] infoAboutSecondFolder = ShowerDirectory.ShowAllFiles(ConfigurationManager.AppSettings["PathFolderSecond"].ToString());
            this.DirectoryInfo1 = new HashSet<FileInfo>();
            foreach (string res in infoAboutFirstFoder)
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(res);
                this.DirectoryInfo1.Add(fileInfo);
            }

            foreach (string res in infoAboutSecondFolder)
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(res);
                this.DirectoryInfo2.Add(fileInfo);
            }
        }

        public static string[] ShowAllFiles(string path)
        {
            return Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
        }

        public HashSet<FileInfo> SymmetricalDifference()
        {
            HashSet<FileInfo> except1 = this.DirectoryInfo1.Except(this.DirectoryInfo2, new FileNameComparer()).ToHashSet();
            HashSet<FileInfo> except2 = this.DirectoryInfo2.Except(this.DirectoryInfo1, new FileNameComparer()).ToHashSet();
            HashSet<FileInfo> resultWithUniqueValues = except1.Concat(except2).ToHashSet();
            return resultWithUniqueValues;
        }

        public HashSet<FileInfo> ExpectDirectory()
        {
            HashSet<FileInfo> resultWithUniqueValues = this.DirectoryInfo1.Except(this.DirectoryInfo2, new FileNameComparer()).ToHashSet();
            return resultWithUniqueValues;
        }

        public HashSet<FileInfo> Intersection()
        {
            HashSet<FileInfo> resultWithUniqueValues = this.DirectoryInfo1.Intersect(this.DirectoryInfo2, new FileNameComparer()).ToHashSet();
            return resultWithUniqueValues;
        }
    }
}
