using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] effects = ReadIntArray();
            int[] casing = ReadIntArray();

            Stack<int> bombEffects = new Stack<int>(effects.Reverse());
            Stack<int> bombCasing = new Stack<int>(casing);
            Dictionary<string, int> bombPouch = new Dictionary<string, int>()
            {
                { "Cherry Bombs", 0 },
                { "Datura Bombs", 0 },
                { "Smoke Decoy Bombs",0 }
            };

            bool isBene = false;

            while (bombCasing.Count > 0 && bombEffects.Count > 0)
            {
                BombCheck(bombEffects, bombCasing, bombPouch);
                if (isEnoughBombs(bombPouch))
                {
                    isBene = true;
                    break;
                }
            }

            Console.WriteLine(isBene ? "Bene! You have successfully filled the bomb pouch!" 
                : "You don't have enough materials to fill the bomb pouch.");

            Console.WriteLine(bombEffects.Count == 0 ? "Bomb Effects: empty" 
                : $"Bomb Effects: {string.Join(", ", bombEffects)}");

            Console.WriteLine(bombCasing.Count == 0 ? "Bomb Casings: empty"
                : $"Bomb Casings: {string.Join(", ", bombCasing)}");

            foreach (var bomb in bombPouch.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }

        }

        private static bool isEnoughBombs(Dictionary<string, int> bombPouch)
        {
            bool isEnough = true;
            foreach (var bomb in bombPouch)
            {
                if (bomb.Value < 3)
                {
                    isEnough = false;
                    break;
                }
            }
            return isEnough;
        }

        private static void BombCheck(Stack<int> bombEffects, Stack<int> bombCasing, Dictionary<string, int> bombPouch)
        {
            if (bombEffects.Peek() + bombCasing.Peek() == 40)
            {
                bombCasing.Pop();
                bombEffects.Pop();
                bombPouch["Datura Bombs"]++;
            }
            else if (bombEffects.Peek() + bombCasing.Peek() == 60)
            {
                bombCasing.Pop();
                bombEffects.Pop();
                bombPouch["Cherry Bombs"]++;
            }
            else if (bombEffects.Peek() + bombCasing.Peek() == 120)
            {
                bombCasing.Pop();
                bombEffects.Pop();
                bombPouch["Smoke Decoy Bombs"]++;
            }
            else
            {
                int temp = bombCasing.Pop();
                temp -= 5;
                bombCasing.Push(temp);
            }
        }

        private static int[] ReadIntArray()
        {
            return Console.ReadLine()
                            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
        }
    }
}
