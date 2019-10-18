using Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ConsoleApp1
{
    class Program
    {
        public static object MyLogger { get; private set; }
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            //ShowerDirectory sd = new ShowerDirectory();
            //String filesAndDerectories = sd.ShowerDirectoryAndFiles("C:\\Users\\GOOD\\source\\repos\\EpamTrainingSecond",new StringBuilder());
            //Console.WriteLine(filesAndDerectories);
            //Console.ReadLine();
            MyLogger logger = new MyLogger();
            logger.SrcLogger = new DataBaseLogger();
            logger.SrcLogger.WriteMessage(new Exception());
            //logger.SrcLogger.ReadMessage();
            //try
            //{
            //    Logger.Info("Hello world");
               
            //    throw new IndexOutOfRangeException();
            //}
            //catch (Exception ex)
            //{
            //    Logger.Error(ex, "Goodbye cruel world");
            //    Console.WriteLine("sdfdsfdsfsd");
            //}
            //foreach (var drive in DriveInfo.GetDrives())
            //{
            //    Console.WriteLine(drive.Name);
            //}



            Console.ReadKey();
        }
    }
}
