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
        string PathOfFile { get; set; } = ConfigurationManager.AppSettings["PathToLog"].ToString();

        public void ReadMessage()
        {

            using (StreamReader sr = new StreamReader(PathOfFile))
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
            if (!File.Exists(PathOfFile))
            {
                File.Create(PathOfFile);
            }
            using (StreamWriter sw = File.AppendText(PathOfFile))
            {
                sw.WriteLine(e.Message);
            }
        }
    }
}
