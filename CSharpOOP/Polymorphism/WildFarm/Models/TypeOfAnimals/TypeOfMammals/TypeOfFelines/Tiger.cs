namespace WildFarm.Models.TypeOfAnimals.TypeOfMammals.TypeOfFelines
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight,  livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name != "Meat")
            {
                throw new ExeptionTypeOfFood($"Tiger does not eat {food.GetType().Name}!");
            }
            this.Weight += food.Quantity * 1.00;
            this.FoodEaten = food.Quantity;
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
