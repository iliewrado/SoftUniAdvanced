using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _01ListyIterator
{
    public class ListyIterator<T>
    {
        private readonly List<T> items;
        public int index { get; private set; }
        public ListyIterator(params T[] elements)
        {
            this.items = new List<T>(elements);
            index = 0;
        }
        public List<T> Items => items;
        public bool Move()
        {
            if (index + 1 < items.Count)
            {
                index++;
                return true;
            }
            return false;
        }
        public bool HasNext()
        {
            if (index + 1 < items.Count)
            {
                return true;
            }
            return false;
        }
        public void Print()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine($"{items[index]}");
        }
    }
}
