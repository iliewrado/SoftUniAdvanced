using System.Collections.Generic;
using System.Linq;
namespace BoxOfT
{
    public class Box<T>
    {
        private readonly List<T> items;
        public int Count
        {
            get
            {
                return items.Count;
            }
        }
        public Box()
        {
            items = new List<T>();
        }
        public void Add(T element)
        {
            items.Add(element);
        }
        public T Remove()
        {
            T element = items.LastOrDefault();
            items.Remove(element);

            return element;
        }
    }
}
