using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations.Classes
{
    using Interfaces;
    public class Pet : IPet
    {
        public string Name { get; private set; }

        public string Birthdate { get; private set; }
        public Pet(string name,string date)
        {
            this.Name = name;
            this.Birthdate = date;
        }
    }
}
