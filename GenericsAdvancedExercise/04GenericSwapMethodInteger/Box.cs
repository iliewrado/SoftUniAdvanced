using System.Collections.Generic;

namespace GenericSwapMethodInteger
{
    class Box<T>
    {
        public List<T> Items { get; set; }
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
        public void Add(T element)
        {
            Items.Add(element);
            Count++;
        }
        public void Swap(Box<T> items, int index, int second)
        {
            T item = items[index];
            items[index] = items[second];
            items[second] = item;
        }
    }
}
