using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person personPeter = new Person() { Name = "Peter", Age = 20 };

            Person personGeorge = new Person();
            personGeorge.Age = 18;
            personGeorge.Name = "George";

            Person personSam = new Person("Sam", 43);
        }
    }
}
