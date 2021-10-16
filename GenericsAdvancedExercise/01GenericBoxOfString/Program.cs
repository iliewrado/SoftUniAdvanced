using System;
namespace GenericBoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                Box<string> items = new Box<string>(input);
                Console.WriteLine(items.ToString());
            }
        }
    }
}
