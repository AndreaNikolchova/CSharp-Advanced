namespace WildFarm.Models.TypeOfAnimals.TypeOfMammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name != "Vegetable"&& food.GetType().Name != "Fruit")
            {
                throw new ExeptionTypeOfFood($"Mouse does not eat {food.GetType().Name}!");
            }
            this.Weight += food.Quantity * 0.10;
            this.FoodEaten = food.Quantity;
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
