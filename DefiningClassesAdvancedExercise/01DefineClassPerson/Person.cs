﻿namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;
        public Person()
        {

        }
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name
        {
            get { return this.name; }
            set { this.Name = name; }
        }
        public int Age 
        {
            get { return this.age; }
            set { this.Age = age; } 
        }
    }
}
