using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string _name;
        public string Name 
        {
            get { return _name; }
            set
            {
                if (value== string.Empty)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this._name = value;
            }
        }
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (value <= 0)
                {
                   throw new ArgumentException("Invalid input!");
                }
                this._age = value;
            }
        }
        private string _gender;
        public string Gender 
        {
            get { return _gender; } 
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this._gender = value;
            }
        }
        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        public abstract string ProduceSound();
        public override string ToString()
        {
            return $"{this.GetType().Name}{Environment.NewLine}{this.Name} {this.Age} {this.Gender}{Environment.NewLine}{this.ProduceSound()}";
        }
    }
}
