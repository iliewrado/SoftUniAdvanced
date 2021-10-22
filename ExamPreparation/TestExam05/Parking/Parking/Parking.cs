using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        public string Type { get; set; }
        public int Capacity { get; set; }
        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }
        public int Count => data.Count;
        public void Add(Car car)
        {
            if (data.Count < Capacity)
            {
                data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            if (data.Exists(x => x.Manufacturer == manufacturer && x.Model == model))
            {
                Car car = data.Find(x => x.Manufacturer == manufacturer && x.Model == model);
                data.Remove(car);
                return true;
            }
            return false;
        }
        public Car GetLatestCar()
        {
            if (data.Count > 0)
            {
                Car car = data.OrderByDescending(x => x.Year).FirstOrDefault();
                return car;
            }
            return null;
        }
        public Car GetCar(string manufacturer, string model)
        {
            if (data.Count > 0 
                && data.Exists(x => x.Manufacturer == manufacturer 
                && x.Model == model))
            {
                Car car = data.FirstOrDefault(x => x.Manufacturer == manufacturer 
                && x.Model == model);
                return car;
            }
            return null;
        }
        public string GetStatistics()
        {
            StringBuilder parking = new StringBuilder();
            parking.AppendLine($"The cars are parked in {Type}:");
            foreach (var car in data)
            {
                parking.AppendLine(car.ToString());
            }
            return parking.ToString().TrimEnd();
        }
    }
}
