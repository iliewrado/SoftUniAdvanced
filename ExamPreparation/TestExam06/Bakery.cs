using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;
        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }

        public void Add(Employee employee)
        {
            if (data.Count < Capacity)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Employee employee = data.FirstOrDefault(x => x.Name == name);
            return data.Remove(employee);
        }

        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public Employee GetEmployee(string name)
        {
            return data.FirstOrDefault(x => x.Name == name);
        }

        public string Report()
        {
            StringBuilder backeryInfo = new StringBuilder();
            backeryInfo.AppendLine($"Employees working at Bakery {this.Name}:");
            foreach (var item in data)
            {
                backeryInfo.AppendLine(item.ToString());
            }
            return backeryInfo.ToString().TrimEnd();
        }
    }
}
