using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04Froggy
{
    class Lake<T> : IEnumerable<int>
    {
        public List<int> items { get; private set; }
        public Lake(int[] elements)
        {
            items = new List<int>(elements);
        }
        public IEnumerator<int> GetEnumerator()
        {
            if (items.Count % 2 == 0)
            {
                for (int i = 0; i < items.Count; i += 2)
                {
                    yield return items[i];
                }
                for (int i = items.Count-1; i > 0; i-=2)
                {
                    yield return items[i];
                }
            }
            else
            {
                for (int i = 0; i < items.Count; i += 2)
                {
                    yield return items[i];
                }
                for (int i = items.Count - 2; i > 0; i -= 2)
                {
                    yield return items[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
