using PrinterHelpers;
using PrinterHelpers.PrintersImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training5.Task1;

namespace RunProject.RunImplementations.Training5
{
    public class RunImplementationForSerializerCar : IRun
    {
        public RunImplementationForSerializerCar(IPrinter printer)
        {
            this.Printer = printer;
        }

        public IPrinter Printer { get; set; } = new ConsolePrinter();

        public bool Run()
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Car { Marck = "BMVbinary", Speed = 145 });
            cars.Add(new Car { Marck = "FERARYbinary", Speed = 340 });

            CarSerializator serializer = new CarSerializator();
            serializer.SerializeForBinary(cars);
            List<Car> carsDeserialize = new List<Car>();
            carsDeserialize = serializer.DeserializeForBinary();
            foreach (var car in carsDeserialize)
            {
                this.Printer.Writeline(car.ToString());
            }

            cars[0].Marck = "BMVxml";
            cars[1].Marck = "FERARYxml";
            serializer.SerializeForXML(cars);
            carsDeserialize = new List<Car>();
            carsDeserialize = serializer.DeserializeForXML();
            foreach (var car in carsDeserialize)
            {
                this.Printer.Writeline(car.ToString());
            }

            cars[0].Marck = "BMVjson";
            cars[1].Marck = "FERARYjson";
            string jsonCars = serializer.SerializeForJson(cars);
            carsDeserialize = new List<Car>();
            carsDeserialize = serializer.DeserializeForJson(jsonCars);
            foreach (var car in carsDeserialize)
            {
                this.Printer.Writeline(car.ToString());
            }

            Console.ReadKey();
            return true;
        }
    }
}
