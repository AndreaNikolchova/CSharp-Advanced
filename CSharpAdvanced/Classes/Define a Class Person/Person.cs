using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;
        public List<Person> People = new List<Person>();
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set 
            {
                if (value>30)
                {
                    age = value;
                }
            }
        }
      
        //public Person()
        //{
        //    this.name = "No name";
        //    this.age = 1;
        //}
        //public Person(int age)
        //{
        //    this.name = "No name";
        //    this.age = age;
        //}
        //public Person(string name, int age)
        //{
        //    this.name = name;
        //    this.age = age;
        //}
    }
}
