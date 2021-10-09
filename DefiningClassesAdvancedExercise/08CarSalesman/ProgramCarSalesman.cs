using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Engine engine = new Engine();
                string[] engineInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                engine.Model = engineInfo[0];
                engine.EnginePower = engineInfo[1];
                if (engineInfo.Length == 3)
                {
                    if (char.IsDigit(engineInfo[2][0]))
                    {
                        engine.Displacement = engineInfo[2];
                    }
                    else
                    {
                        engine.Efficiency = engineInfo[2];
                    }
                }
                else if (engineInfo.Length == 4)
                {
                    engine.Displacement = engineInfo[2];
                    engine.Efficiency = engineInfo[3];
                }
                engines.Add(engine);
            }
            List<Car> vehicles = new List<Car>();
            count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Car car = new Car() { Engine = new Engine() };
                string[] carInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                car.Model = carInfo[0];
                if (engines.Exists(x => x.Model == carInfo[1]))
                {
                    int index = engines.FindIndex(x => x.Model == carInfo[1]);
                    car.Engine = engines[index];
                }
                if (carInfo.Length == 3)
                {
                    if (char.IsDigit(carInfo[2][0]))
                    {
                        car.Weight = carInfo[2];
                    }
                    else
                    {
                        car.Color = carInfo[2];
                    }
                }
                else if (carInfo.Length == 4)
                {
                    car.Weight = carInfo[2];
                    car.Color = carInfo[3];
                }
                vehicles.Add(car);
            }
            foreach (var car in vehicles)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
