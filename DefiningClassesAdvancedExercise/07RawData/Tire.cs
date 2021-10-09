namespace DefiningClasses
{
    public class Tire
    {
        public double TirePressure { get; set; }
        public int TireAge { get; set; }
        public Tire(double pressure, int tireAge)
        {
            TirePressure = pressure;
            TireAge = tireAge;
        }
    }
}
