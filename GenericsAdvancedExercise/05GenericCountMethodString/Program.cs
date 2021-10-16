using System;

namespace GenericCountMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Box<string> items = new Box<string>();
            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                items.Add(input);
            }
            string comparer = Console.ReadLine();

            Console.WriteLine(Compare(items, comparer));    
        }
        public static int Compare<T>(Box<T> items, T comparer)
            where T : IComparable<T>
        {
            int count = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].CompareTo(comparer) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
