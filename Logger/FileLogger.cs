// <copyright file="FileLogger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Logger
{
    using System;
    using System.Configuration;
    using System.IO;

    public class FileLogger : ILogger
    {
        public string PathOfFile { get; set; } = ConfigurationManager.AppSettings["PathToLog"].ToString();

        public void ReadMessage()
        {
            using (StreamReader sr = new StreamReader(this.PathOfFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public void WriteMessage(Exception e)
        {
            if (!File.Exists(this.PathOfFile))
            {
                File.Create(this.PathOfFile);
            }

            using (StreamWriter sw = File.AppendText(this.PathOfFile))
            {
                sw.WriteLine(e.Message);
            }
        }
    }
}
