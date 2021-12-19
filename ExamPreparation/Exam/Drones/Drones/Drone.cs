using System.Text;

namespace Drones
{
    public class Drone
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Range { get; set; }
        public bool Available { get; set; } = true;

        public Drone(string name, string brand, int range)
        {
            Name = name;
            Brand = brand;
            Range = range;
        }

        public override string ToString()
        {
            StringBuilder droneInfo = new StringBuilder();
            droneInfo.AppendLine($"Drone: {Name}");
            droneInfo.AppendLine($"Manufactured by: {Brand}");
            droneInfo.AppendLine($"Range: {Range} kilometers");
            return droneInfo.ToString().TrimEnd();
        }
    }
}
