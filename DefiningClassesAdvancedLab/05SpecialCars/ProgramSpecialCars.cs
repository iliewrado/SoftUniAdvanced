using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "No more tires")
            {
                double[] tireInfo = Spliter(input);

                Tire[] tire = new Tire[]
                {
                    new Tire((int)tireInfo[0], tireInfo[1]),
                    new Tire((int)tireInfo[2], tireInfo[3]),
                    new Tire((int)tireInfo[4], tireInfo[5]),
                    new Tire((int)tireInfo[6], tireInfo[7])
                };
                tires.Add(tire);
            }
            List<Engine> engines = new List<Engine>();
            while ((input = Console.ReadLine()) != "Engines done")
            {
                double[] engineInfo = Spliter(input);
                Engine engine = new Engine((int)engineInfo[0], engineInfo[1]);
                engines.Add(engine);
            }
            List<Car> cars = new List<Car>();
            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] command = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int engineIndex = int.Parse(command[5]);
                int tiresIndex = int.Parse(command[6]);
                Car car = new Car()
                {
                    Make = command[0],
                    Model = command[1],
                    Year = int.Parse(command[2]),
                    FuelQuantity = double.Parse(command[3]),
                    FuelConsumption = double.Parse(command[4]),
                    Engine = engines[engineIndex],
                    Tires = tires[tiresIndex],
                };
                cars.Add(car);
            }
            cars = cars.Where(x => x.Year >= 2017
            && x.Engine.HorsePower > 330
            && x.Tires.Sum(y => y.Pressure) >= 9
            && x.Tires.Sum(y => y.Pressure) <= 10)
                .ToList();
            foreach (var car in cars)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }
        }

        private static double[] Spliter(string input)
        {
            return input
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(double.Parse)
               .ToArray();
        }
    }
}
