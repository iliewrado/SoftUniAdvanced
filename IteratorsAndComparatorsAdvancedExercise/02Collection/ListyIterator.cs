using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _02Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private readonly List<T> items;
        public int index { get; private set; }
        public ListyIterator(params T[] elements)
        {
            this.items = new List<T>(elements);
            index = 0;
        }
        public bool Move()
        {
            if (++index < items.Count)
            {
                return true;
            }
            return false;
        }
        public bool HasNext()
        {
            if (++index < items.Count)
            {
                index--;
                return true;
            }
            index--;
            return false;
        }
        public void Print()
        {
            if (items.Count > 0 && index < items.Count)
            {
                Console.WriteLine(items[index]);
            }
            else
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
        }
        public void PrintAll()
        {
            Console.WriteLine(string.Join(' ', items));
        }
        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
