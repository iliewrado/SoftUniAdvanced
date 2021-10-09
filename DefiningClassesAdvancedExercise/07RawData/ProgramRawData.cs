using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Car> vehicles = new List<Car>();
            for (int i = 0; i < count; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine engine = new Engine {
                EngineSpeed = int.Parse(carInfo[1]),
                EnginePower = int.Parse(carInfo[2]) };
                Tire[] tires = new Tire[4]
                {
                    new Tire(double.Parse(carInfo[5]), int.Parse(carInfo[6])),
                    new Tire(double.Parse(carInfo[7]), int.Parse(carInfo[8])),
                    new Tire(double.Parse(carInfo[9]), int.Parse(carInfo[10])),
                    new Tire(double.Parse(carInfo[11]), int.Parse(carInfo[12])),
                };
                Car car = new Car
                {
                    Model = carInfo[0],
                    Engine = engine,
                    CargoWeight = int.Parse(carInfo[3]),
                    CargoType = carInfo[4],
                    Tires = tires,
                };
                vehicles.Add(car);
            }
            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in vehicles.Where(x => x.CargoType == "fragile")
                    .Where(y => y.Tires.Any(x => x.TirePressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flammable")
            {
                foreach (var car in vehicles
                    .Where(x => x.CargoType == "flammable" 
                && x.Engine.EnginePower > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
