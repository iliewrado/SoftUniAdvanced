using System;
using System.Collections.Generic;
using System.Linq;

namespace _03SimpleCalculator
{
    class ProgramSimpleCalculator
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            Stack<string> elements = new Stack<string>(input);

            while (elements.Count > 1)
            {
                string[] temp = new string[3];
                int sum = 0;
                for (int i = 0; i < 3; i++)
                {
                    temp[i] = elements.Pop();
                }
                if (temp[1] == "-")
                {
                    sum = int.Parse(temp[0]) - int.Parse(temp[2]);
                }
                else
                {
                    sum = int.Parse(temp[0]) + int.Parse(temp[2]);
                }
                elements.Push(sum.ToString());
            }
            Console.WriteLine(elements.Pop());
        }
    }
}
