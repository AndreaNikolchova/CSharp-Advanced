using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private string favouriteFood;
        public string Name
        {
            get { return this.name; }
            protected set { this.name = value; }
        }
        public string FavoriteFood
        {
            get { return this.favouriteFood;}
            protected set { this.favouriteFood = value;}
        }
        public Animal(string name, string favouriteFood)
        {
            this.Name = name;
            this.FavoriteFood = favouriteFood;
        }
        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my fovourite food is {this.FavoriteFood}";
        }
    }
}
