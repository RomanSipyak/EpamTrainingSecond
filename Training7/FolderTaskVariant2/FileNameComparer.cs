// <copyright file="FileNameComparer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Training7.FolderTaskVariant2
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class FileNameComparer : IEqualityComparer<FileInfo>
    {
        public bool Equals(FileInfo x, FileInfo y)
        {
            if (x == y)
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            return string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(FileInfo obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
