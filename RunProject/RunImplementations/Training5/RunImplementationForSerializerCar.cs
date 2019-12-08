// <copyright file="RunImplementationForSerializerCar.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RunProject.RunImplementations.Training5
{
    using System;
    using System.Collections.Generic;
    using global::Training5.Task1;
    using PrinterHelpers;
    using PrinterHelpers.PrintersImplementations;

    public class RunImplementationForSerializerCar : IRun
    {
        public RunImplementationForSerializerCar(IPrinter printer)
        {
            this.Printer = printer;
        }

        public IPrinter Printer { get; set; } = new ConsolePrinter();

        public bool Run()
        {
            this.Printer.Writeline("This part serialize and deserialize cars");
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
