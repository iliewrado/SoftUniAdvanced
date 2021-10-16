using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> elements;
        public int Count { get; private set; }

        public Stack()
        {
            this.elements = new List<T>();
        }
        public void Push(T item)
        {
            elements.Add(item);
            Count++;
        }
        public void Pop()
        {
            if (Count == 0)
            {
                Console.WriteLine("No elements");
            }
            else
            {
                elements.RemoveAt(Count - 1);
                Count--;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = elements.Count-1; i >=0 ; i--)
            {
                yield return elements[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}
