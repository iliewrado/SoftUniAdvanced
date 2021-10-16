using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class Threeuple<T, U, V>
    {
        public T Titem { get; set; }
        public U Uitem { get; set; }
        public V Vitem { get; set; }
        public Threeuple()
        {

        }
        public override string ToString()
        {
            return $"{Titem} -> {Uitem} -> {Vitem}";
        }
    }
}
