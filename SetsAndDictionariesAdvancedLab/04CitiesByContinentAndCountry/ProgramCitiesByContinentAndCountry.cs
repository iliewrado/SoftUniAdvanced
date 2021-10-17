using System;
using System.Collections.Generic;

namespace _04CitiesByContinentAndCountry
{
    class ProgramCitiesByContinentAndCountry
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] continetInfo = ReadArrayConsole();
                string continent = continetInfo[0];
                string countrie = continetInfo[1];
                string city = continetInfo[2];

                if (!continents.ContainsKey(continent))
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!continents[continent].ContainsKey(countrie))
                {
                    continents[continent].Add(countrie, new List<string>());
                }
                continents[continent][countrie].Add(city);
            }
            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var countrie in continent.Value)
                {
                    Console.WriteLine($"{countrie.Key} -> {string.Join(", ", countrie.Value)}");
                }
            }
        }
        public static string[] ReadArrayConsole()
        {
            return Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
