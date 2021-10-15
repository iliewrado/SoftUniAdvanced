using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] basket = ReadIntArray();
            int[] freshnessInfo = ReadIntArray();

            Queue<int> ingredients = new Queue<int>(basket);
            Stack<int> freshness = new Stack<int>(freshnessInfo);
            Dictionary<string, int> dishes = new Dictionary<string, int>()
            {
                { "Dipping sauce", 0 },
                { "Green salad", 0 },
                { "Chocolate cake", 0 },
                { "Lobster", 0 }
            };
            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }
                int ingredient = ingredients.Peek();
                int cook = ingredients.Dequeue() * freshness.Pop();
                switch (cook)
                {
                    case 150:
                        dishes["Dipping sauce"]++;
                        break;
                    case 250:
                        dishes["Green salad"]++;
                        break;
                    case 300:
                        dishes["Chocolate cake"]++;
                        break;
                    case 400:
                        dishes["Lobster"]++;
                        break;
                    default:
                        ingredient += 5;
                        ingredients.Enqueue(ingredient);
                        break;
                }
            }
            bool isSuccessful = true;
            foreach (var dish in dishes)
            {
                if (dish.Value == 0)
                {
                    isSuccessful = false;
                    break;
                }
            }
            if (isSuccessful)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }
            foreach (var dish in dishes.Where(x => x.Value > 0).OrderBy(x => x.Key))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
        }
        private static int[] ReadIntArray()
        {
            return Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
        }
    }
}

