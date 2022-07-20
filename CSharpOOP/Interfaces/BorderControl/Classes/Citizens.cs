using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizens : IPerson
    {
        public int Age { get; private set; }

        public string Name { get; private set; }

        public string Id { get; private set; }
        public Citizens(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
    }
}
