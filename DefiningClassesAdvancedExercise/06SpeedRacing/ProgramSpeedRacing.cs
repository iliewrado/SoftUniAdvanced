using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> vehicles = new Dictionary<string, Car>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Car vehicle = new Car();
                vehicle.FuelAmount = double.Parse(carInfo[1]);
                vehicle.FuelConsumptionPerKilometer = double.Parse(carInfo[2]);
                vehicle.TravellDistance = 0;
                vehicles.Add(carInfo[0], vehicle);
            }
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = command[1];
                double kilometers = double.Parse(command[2]);
                vehicles[model].Drive(kilometers);
            }
            foreach (var car in vehicles)
            {
                Console.WriteLine($"{car.Key} {car.Value.FuelAmount:f2} {car.Value.TravellDistance}");
            }
        }
    }
}
