using System;

namespace _02RecursiveFactorial
{
    class ProgramRecursiveFactorial
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            long factorial = CalculateFacTorial(number);

            Console.WriteLine(factorial);
        }

        private static long CalculateFacTorial(int number)
        {
            if (number == 0)
            {
                return 1;
            }
            return number * CalculateFacTorial(number - 1);
        }
    }
}
