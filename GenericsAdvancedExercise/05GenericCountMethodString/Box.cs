using System;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    public class Box<T> 
        where T : IComparable<T>
    {
        public T Element { get; }
        public List<T> Items { get; }
        public T this[int index]
        {
            get
            {
                return Items[index];
            }
            set
            {
                Items[index] = value;
            }
        }
        public int Count { get; private set; }
        public Box()
        {
            Items = new List<T>();
        }
        public Box(T element)
        {
            Element = element; 
        }
        public void Add(T element)
        {
            Items.Add(element);
            Count++;
        }
        public void Swap(List<T> items, int index, int second)
        {
            T item = items[index];
            items[index] = items[second];
            items[second] = item;
        }
    }
}
