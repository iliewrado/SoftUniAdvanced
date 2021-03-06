using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private readonly List<Drone> drones;
        public IReadOnlyCollection<Drone> Drones => drones;

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count => this.drones.Count;
       
        public Airfield(string name, int capacity, double landing)
        {
            drones = new List<Drone>();
            Name = name;
            Capacity = capacity;
            LandingStrip = landing;
        }

        public string AddDrone(Drone drone)
        {
            if (drone.Range > LandingStrip)
            {
                return "Invalid drone.";
            }
            if (string.IsNullOrWhiteSpace(drone.Name))
            {
                return "Invalid drone.";
            }
            
            if (string.IsNullOrWhiteSpace(drone.Brand))
            {
                return "Invalid drone.";
            }
            
            if (drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            
            if (drones.Count >= Capacity)
            {
                return "Airfield is full.";
            }

            drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            Drone drone = drones.FirstOrDefault(x => x.Name == name);
            if (drone != null)
            {
                drones.Remove(drone);
                return true;
            }
            return false;
        }

        public int RemoveDroneByBrand(string brand)
        {
            int count = 0;
            List<Drone> drones = this.drones.Where(x => x.Brand == brand).ToList();
            
            foreach (var drone in drones)
            {
                if (RemoveDrone(drone.Name))
                {
                    count++;
                }
            }

            return count;
        }

        public Drone FlyDrone(string name)
        {
            Drone drone = drones.FirstOrDefault(x => x.Name == name);
            
            if (drone != null)
            {
                drone.Available = false;
            }

            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> drones = this.drones.Where(x => x.Range >= range 
                && x.Available == true).ToList();
            foreach (var drone in drones)
            {
                drone.Available = false;
            }
            return drones;
        }

        public string Report()
        {
            StringBuilder airfieldInfo = new StringBuilder();
            airfieldInfo.AppendLine($"Drones available at {this.Name}:");
            
            foreach (var drone in drones.Where(x => x.Available == true))
            {
                airfieldInfo.AppendLine(drone.ToString());
            }

            return airfieldInfo.ToString().TrimEnd();
        }
    }
}
