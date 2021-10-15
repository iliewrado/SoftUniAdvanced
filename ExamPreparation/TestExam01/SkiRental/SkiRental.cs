using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;
        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Ski>();
        }
        public void Add(Ski ski)
        {
            if (data.Count < Capacity)
            {
                data.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            int index = data.FindIndex(x => x.Manufacturer == manufacturer
            && x.Model == model);
            if (index >= 0)
            {
                data.RemoveAt(index);
                return true;
            }
            return false;
        }
        public Ski GetNewestSki()
        {
            if (data.Count > 0)
            {
                return data.OrderByDescending(x => x.Year)
                    .FirstOrDefault();
            }
            return null;
        }
        public Ski GetSki(string manufacturer, string model)
        {
            int index = data.FindIndex(x => x.Manufacturer == manufacturer
            && x.Model == model);
            if (index >= 0)
            {
                Ski ski = data[index];
                return ski;
            }
            return null;
        }
        public string GetStatistics()
        {
            StringBuilder statistics = new StringBuilder();
            statistics.AppendLine($"The skis stored in {Name}:");
            foreach (var ski in data)
            {
                statistics.AppendLine(ski.ToString());
            }
            return statistics.ToString().TrimEnd();
        }
    }
}
