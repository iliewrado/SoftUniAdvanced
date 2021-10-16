using System;
namespace Guild
{
    public class Player
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public string Description;
        public string Rank;

        public Player(string name, string clas)
        {
            Name = name;
            Class = clas;
            Rank = "Trial";
            Description = "n/a";
        }
        public override string ToString()
        {
            return $"Player {Name}: {Class}{Environment.NewLine}Rank: {Rank}{Environment.NewLine}Description: {Description}";
        }
    }
}