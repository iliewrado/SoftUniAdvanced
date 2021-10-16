using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _06EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person()
        {

        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age);
        }

        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = Age.CompareTo(other.Age);
            }
            return result;
        }
        public override bool Equals(object obj)
        {
            Person other = obj as Person;
            return Name == other.Name && Age == other.Age;

        }
    }
}
