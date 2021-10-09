namespace DefiningClasses
{
    public class Engine
    {
        public string Model { get; set; }
        public string EnginePower { get; set; }
        public string Displacement { get; set; }
        public string Efficiency { get; set; }

        public Engine()
        {
            Model = "n/a";
            EnginePower = "n/a";
            Displacement = "n/a";
            Efficiency = "n/a";
        }
        public Engine(string model, string power)
            :this()
        {
            Model = model;
            EnginePower = power;
        }
        public Engine(string model, string power, string displacement)
           : this(model, power)
        {
            Displacement = displacement;
        }
        public Engine(string model, string power, string displacement, string efficiency)
           : this (model, power, displacement)
        {
            Efficiency = efficiency;
        }
    }
}
