// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TestProjectForLoggers
{
    using System;
    using Logger;

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
