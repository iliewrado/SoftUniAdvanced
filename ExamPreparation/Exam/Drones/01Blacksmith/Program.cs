using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] steelInput = ReadIntArray();
            int[] carbonInput = ReadIntArray();

            Queue<int> steel = new Queue<int>(steelInput);
            Stack<int> carbon = new Stack<int>(carbonInput);

            Dictionary<string, int> swords = new Dictionary<string, int>()
            {
                {"Gladius", 0 },
                {"Shamshir", 0 },
                {"Katana", 0 },
                {"Sabre", 0 },
                {"Broadsword", 0 }
            };

            while (steel.Count > 0 && carbon.Count > 0)
            {
                int carbonValue = carbon.Pop();
                int sum = steel.Dequeue() + carbonValue;
                switch (sum)
                {
                    case 70:
                        swords["Gladius"]++;
                        break;
                    case 80:
                        swords["Shamshir"]++;
                        break;
                    case 90:
                        swords["Katana"]++;
                        break;
                    case 110:
                        swords["Sabre"]++;
                        break;
                    case 150:
                        swords["Broadsword"]++;
                        break;
                    default:
                        carbonValue += 5;
                        carbon.Push(carbonValue);
                        break;
                }
            }

            int totalNumberOfSwords = 0;
            foreach (var sword in swords.Where(x => x.Value > 0))
            {
                totalNumberOfSwords += sword.Value;
            }

            Console.WriteLine(totalNumberOfSwords > 0 ? $"You have forged {totalNumberOfSwords} swords."
                : "You did not have enough resources to forge a sword.");

            string steelLeft = steel.Count > 0 ? $"Steel left: {string.Join(", ", steel)}"
                : "Steel left: none";
            string carbonLeft = carbon.Count > 0 ? $"Carbon left: {string.Join(", ", carbon)}"
                : "Carbon left: none";

            Console.WriteLine(steelLeft);
            Console.WriteLine(carbonLeft);

            foreach (var sword in swords.OrderBy(x => x.Key).Where(x => x.Value > 0))
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }

        }

        private static int[] ReadIntArray()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
