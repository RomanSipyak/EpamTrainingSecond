using Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Training5.Task1;

namespace TestProjectForLoggers
{
    public class Program
    {
        private static readonly NLog.Logger Nlogger = NLog.LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            ////MyLoggerDB
            MyLogger mylogger = new MyLogger();
            mylogger.SrcLogger = new DataBaseLogger();
            mylogger.SrcLogger.WriteMessage(new Exception());
            mylogger.SrcLogger.ReadMessage();
            ////MyLoggerDB
            ////MyLog gerFile
            mylogger = new MyLogger();
            mylogger.SrcLogger = new FileLogger();
            mylogger.SrcLogger.WriteMessage(new Exception());
            mylogger.SrcLogger.ReadMessage();
            ////MyLog gerFile
            ////TestNlog 
            try
            {
                Nlogger.Info("Hello world");

                throw new IndexOutOfRangeException();
            }
            catch (Exception ex)
            {
                Nlogger.Error(ex, "Goodbye cruel world");
            }
            ////TestNlog 
            Console.ReadKey();
        }
    }
}
