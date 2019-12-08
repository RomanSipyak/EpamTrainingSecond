// <copyright file="PrinterToFile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Training8
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;

    public class PrinterToFile : Printer
    {
        public string PathOfFile { get; set; } = ConfigurationManager.AppSettings["PathToFile"].ToString();

        public List<double> Read()
        {
            List<double> listvalue = new List<double>();
            if (!File.Exists(ConfigurationManager.AppSettings["PathToValueFile"].ToString()))
            {
                throw new DirectoryNotFoundException();
            }

            using (StreamReader streamReader = new StreamReader(ConfigurationManager.AppSettings["PathToValueFile"].ToString()))
            {
                string line;
                int i = 0;
                while ((line = streamReader.ReadLine()) != null && i < 2)
                {
                    i++;
                    listvalue.Add(double.Parse(line));
                }

                return listvalue;
            }
        }

        public void Write(string e)
        {
            if (!File.Exists(this.PathOfFile))
            {
                File.Create(this.PathOfFile);
            }

            using (StreamWriter sw = File.AppendText(this.PathOfFile))
            {
                string result = $"Result of operation {e}";
                sw.WriteLine(result);
            }
        }
    }
}
