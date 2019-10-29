// <copyright file="IOperations.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Training3
{
    using System.Text;

    public interface IOperations
    {
        string ShowerDirectoryAndFiles(string path, StringBuilder stringBuilder);

        string SearchInString(string strings, string nameOfFile);

        string SearchByRootPath(string pathForDirectory, string nameOfFile);
    }
}
