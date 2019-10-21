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
            //MyLogger logger = new MyLogger();
            //logger.SrcLogger = new DataBaseLogger();
            //logger.SrcLogger.WriteMessage(new Exception());
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

            List<Car> cars = new List<Car>();
            cars.Add(new Car { Marck = "asds", Speed = 12 });
            cars.Add(new Car { Marck = "13", Speed = 12 });
            CarSerializator serializer = new CarSerializator();
            serializer.SerializeForBinary(cars);
            List<Car> carsDeserialize = new List<Car>();
            carsDeserialize = serializer.DeserializeForBinary();
            foreach (var car in carsDeserialize)
            {
                Console.WriteLine(car);
            }

            serializer.SerializeForXML(cars);
            carsDeserialize = new List<Car>();
            carsDeserialize = serializer.DeserializeForXML();
            foreach (var car in carsDeserialize)
            {
                Console.WriteLine(car);
            }
            string jsonCars = serializer.SerializeForJson(cars);
            carsDeserialize = new List<Car>();
            carsDeserialize = serializer.DeserializeForJson(jsonCars);
            foreach (var car in carsDeserialize)
            {
                Console.WriteLine(car);
            }
            Console.ReadKey();
        }
    }
}
