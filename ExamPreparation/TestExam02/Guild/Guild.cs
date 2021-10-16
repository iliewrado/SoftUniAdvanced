using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;
        public int Count => roster.Count;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public Guild(string name, int capacity)
        {
            roster = new List<Player>();
            Name = name;
            Capacity = capacity;
        }
        public Player[] KickPlayersByClass(string clas)
        {
            Player[] players = roster.Where(x => x.Class == clas).ToArray();
            roster.RemoveAll(x => x.Class == clas);
            return players;
        }
        public void DemotePlayer(string name)
        {
            if (roster.Exists(x => x.Name == name))
            {
                roster.FirstOrDefault(x => x.Name == name).Rank = "Trial";
            }
        }
        public void PromotePlayer(string name)
        {
            if (roster.Exists(x=> x.Name == name))
            {
                roster.FirstOrDefault(x => x.Name == name).Rank = "Member";
            }
        }
        public bool RemovePlayer(string name)
        {
            if (roster.Exists(x => x.Name == name))
            {
                Player player = roster.FirstOrDefault(x => x.Name == name);
                roster.Remove(player);
                return true;
            }
            return false;
        }
        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }
        public string Report()
        {
            return $"Players in the guild: {Name}{Environment.NewLine}{string.Join(Environment.NewLine, roster)}";
        }
    }
}
