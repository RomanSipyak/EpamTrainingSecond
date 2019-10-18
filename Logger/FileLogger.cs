using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
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
