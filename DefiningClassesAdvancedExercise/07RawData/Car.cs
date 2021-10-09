using System.Linq;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
        public Tire[] Tires { get; set; }
        public Car()
        {

        }
    }
}
