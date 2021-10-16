using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<T,V>
    {
        public T FirstItem { get; set; }
        public V SecondItem { get; set; }
        public Tuple(T firstItem, V secondItem)
        {
            FirstItem = firstItem;
            SecondItem = secondItem;
        }
        public override string ToString()
        {
            return $"{FirstItem} -> {SecondItem}";
        }
    }
}
