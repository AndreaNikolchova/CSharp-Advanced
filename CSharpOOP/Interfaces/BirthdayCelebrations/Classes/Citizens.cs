using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    using Interfaces;
    public class Citizens : IPerson,IBirthable
    {
        public int Age { get; private set; }

        public string Name { get; private set; }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public Citizens(string name, int age, string id,string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }
    }
}
