using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liquidsInfo = ReadIntArray();
            int[] ingredientsInfo = ReadIntArray();
            
            Queue<int> liquids = new Queue<int>(liquidsInfo);
            Stack<int> ingredients = new Stack<int>(ingredientsInfo);
            Dictionary<string, int> bakedFoods = new Dictionary<string, int>()
            {
                {"Bread", 0 },
                {"Cake", 0 },
                {"Pastry", 0 },
                {"Fruit Pie", 0 }
            };
            
            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int liquid = liquids.Dequeue();
                int ingredient = ingredients.Pop();
                switch (liquid + ingredient)
                {
                    case 25:
                        bakedFoods["Bread"]++;
                        break;
                    case 50:
                        bakedFoods["Cake"]++;
                        break;
                    case 75:
                        bakedFoods["Pastry"]++;
                        break;
                    case 100:
                        bakedFoods["Fruit Pie"]++;
                        break;
                    default:
                        ingredient += 3;
                        ingredients.Push(ingredient);
                        break;
                }
            }

            bool areAllBacked = true;
            foreach (var food in bakedFoods)
            {
                if (food.Value == 0)
                {
                    areAllBacked = false;
                    break;
                }
            }
            
            Console.WriteLine(areAllBacked == true ? "Wohoo! You succeeded in cooking all the food!"
                : "Ugh, what a pity! You didn't have enough materials to cook everything.");
            string liquidsOutput = liquids.Count > 0 ? string.Join(", ", liquids) : "none";
            string ingredientsOutput = ingredients.Count > 0 ? string.Join(", ", ingredients) : "none";
            Console.WriteLine($"Liquids left: {liquidsOutput}");
            Console.WriteLine($"Ingredients left: {ingredientsOutput}");
            foreach (var food in bakedFoods.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{food.Key}: {food.Value}");
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
