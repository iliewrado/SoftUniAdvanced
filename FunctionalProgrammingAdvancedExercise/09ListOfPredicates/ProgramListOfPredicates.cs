using System;
using System.Linq;

namespace _09ListOfPredicates
{
    class ProgramListOfPredicates
    {
        static void Main(string[] args)
        {
            int endRange = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int, bool> filter = (divide, num) =>
             {
                 bool isDevisible = true;
                 for (int i = 0; i < divide.Length; i++)
                 {
                     if (num % divide[i] != 0)
                     {
                         isDevisible = false;
                         break;
                     }
                 }
                 return isDevisible;
             };
            int[] divisibleNumbers = Enumerable.Range(1, endRange)
                .Where(x => filter(dividers, x))
                .ToArray();
            Console.WriteLine(string.Join(' ', divisibleNumbers));
        }
    }
}
