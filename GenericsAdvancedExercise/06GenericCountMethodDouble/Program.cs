using System;

namespace GenericCountMethodDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Box<double> items = new Box<double>();
            for (int i = 0; i < count; i++)
            {
                double input = double.Parse(Console.ReadLine());
                items.Add(input);
            }
            double comparer = double.Parse(Console.ReadLine());

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
