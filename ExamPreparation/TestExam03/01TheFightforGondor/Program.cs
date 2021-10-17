using System;
using System.Collections.Generic;
using System.Linq;

namespace _01TheFightforGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());
            int[] defenseInfo = ReadIntArray();

            Queue<int> defenseArmy = new Queue<int>(defenseInfo);
            Stack<int> orcArmy = new Stack<int>();
            for (int i = 0; i < waves; i++)
            {
                int[] orcInfo = ReadIntArray();
                foreach (var wave in orcInfo)
                {
                    orcArmy.Push(wave);
                }
                if (i / 3 == 0 && i > 1)
                {
                    int additionPlate = int.Parse(Console.ReadLine());
                    defenseArmy.Enqueue(additionPlate);
                }
                
                while (orcArmy.Count > 0)
                {
                    if (orcArmy.Peek() > defenseArmy.Peek())
                    {
                        int temp = orcArmy.Pop() - defenseArmy.Dequeue();
                        orcArmy.Push(temp);
                        if (defenseArmy.Count == 0)
                        {
                            break;
                        }
                    }
                    else if (orcArmy.Peek() < defenseArmy.Peek())
                    {
                        int temp = defenseArmy.Dequeue() - orcArmy.Pop();
                        defenseArmy.Enqueue(temp);
                        for (int j = 0; j < defenseArmy.Count - 1; j++)
                        {
                            defenseArmy.Enqueue(defenseArmy.Dequeue());
                        }
                    }
                    else
                    {
                        defenseArmy.Dequeue();
                        orcArmy.Pop();
                        if (defenseArmy.Count == 0)
                        {
                            break;
                        }
                    }
                }
                if (defenseArmy.Count == 0)
                {
                    break;
                }
            }
            
            if (orcArmy.Count > 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcArmy)}");
            }
            else if (defenseArmy.Count > 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", defenseArmy)}");
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
