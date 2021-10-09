using System;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;
        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }
        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(string make, string model, int year, double fuelQantity, double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQantity;
            this.FuelConsumption = fuelConsumption;
        }
        public Car(string make, string model, int year, double fuelQantity,
            double fuelConsumption,Engine engine, Tire[] tires)
            : this(make, model, year, fuelQantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }
        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }
        public Tire[] Tires
        {
            get { return this.tires; }
            set { this.tires = value; }
        }
        public string Make
        {
            get { return this.make; }
            set { this.make = value; }
        }
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value; }
        }
        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }
        public void Drive(double distance)
        {
            bool canDrive = (fuelQuantity - (distance * fuelConsumption)) > 0;
            if (canDrive)
            {
                fuelQuantity -= distance * fuelConsumption;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
        public string WhoAmI()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Make: {this.Make}");
            output.AppendLine($"Model: {this.Model}");
            output.AppendLine($"Year: {this.Year}");
            output.AppendLine($"Fuel: {this.FuelQuantity:F2}L");
            return output.ToString();
        }
    }
}
