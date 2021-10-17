using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;
        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>();
        }
        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine($"Racers participating at {Name}:");
            foreach (var item in data)
            {
                report.AppendLine(item.ToString());
            }
            return report.ToString().TrimEnd();
        }
        public Racer GetFastestRacer()
        {
            if (data.Count > 0)
            {
                Racer racer = data.OrderByDescending(x => x.Car.Speed).FirstOrDefault();
                return racer;
            }
            return null;
        }
        public Racer GetRacer(string name)
        {
            if (data.Count > 0 && data.Exists(x => x.Name == name))
            {
                Racer racer = data.FirstOrDefault(x => x.Name == name);
                return racer;
            }
            return null;
        }
        public Racer GetOldestRacer()
        {
            if (data.Count > 0)
            {
                Racer racer = data.OrderByDescending(x => x.Age).FirstOrDefault();
                return racer;
            }
            return null;
        }
        public bool Remove(string name)
        {
            if (data.Exists(x => x.Name == name))
            {
                Racer racer = data.FirstOrDefault(x => x.Name == name);
                data.Remove(racer);
                return true;
            }
            return false;
        }
        public void Add(Racer racer)
        {
            if (data.Count < Capacity)
            {
                data.Add(racer);
            }
        }
    }
}
