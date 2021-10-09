using System;
using System.Collections.Generic;
using System.Linq;

namespace _03MaximumMinimumElement
{
    class ProgramMaximumMinimumElement
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < count; i++)
            {
                int[] query = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                switch (query[0])
                {
                    case 1:
                        numbers.Push(query[1]);
                        break;
                    case 2:
                        numbers.Pop();
                        break;
                    case 3:
                        if (numbers.Count > 0)
                        {
                            int number = int.MinValue;
                            foreach (var num in numbers)
                            {
                                if (num >= number)
                                {
                                    number = num;
                                }
                            }
                            Console.WriteLine(number);
                        }
                        break;
                    case 4:
                        if (numbers.Count > 0)
                        {
                            int number = int.MaxValue;
                            foreach (var num in numbers)
                            {
                                if (num <= number)
                                {
                                    number = num;
                                }
                            }
                            Console.WriteLine(number);
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
