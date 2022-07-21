namespace WildFarm.Models.TypeOfAnimals.TypeOfMammals.TypeOfFelines
{
    public class Cat : Feline
    {
        public Cat(string name, double weight,  string livingRegion,string breed) : base(name, weight, livingRegion,breed)
        {
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name != "Vegetable" && food.GetType().Name != "Meat")
            {
                throw new ExeptionTypeOfFood($"Cat does not eat {food.GetType().Name}!");
            }
            this.Weight += food.Quantity * 0.30;
            this.FoodEaten = food.Quantity;
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
