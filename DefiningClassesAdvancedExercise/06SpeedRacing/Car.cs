namespace DefiningClasses
{
    public class Car
    {
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravellDistance { get; set; }
        public Car()
        {

        }
        public void Drive(double kilometers)
        {
            if (kilometers * FuelConsumptionPerKilometer <= FuelAmount)
            {
                FuelAmount -= kilometers * FuelConsumptionPerKilometer;
                TravellDistance += kilometers;
            }
            else
            {
                System.Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
