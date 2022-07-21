namespace WildFarm.Models.TypeOfAnimals.TypeOfMammals
{

    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name != "Meat")
            {
                throw new ExeptionTypeOfFood($"Dog does not eat {food.GetType().Name}!");
            }
            this.Weight += food.Quantity * 0.40;
            this.FoodEaten = food.Quantity;
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
