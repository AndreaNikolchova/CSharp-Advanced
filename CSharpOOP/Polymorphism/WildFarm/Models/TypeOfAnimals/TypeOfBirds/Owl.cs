namespace WildFarm.Models.TypeOfAnimals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight,  wingSize)
        {
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name!="Meat")
            {
                throw new ExeptionTypeOfFood($"Owl does not eat {food.GetType().Name}!");
            }
            this.Weight += food.Quantity * 0.25;
            this.FoodEaten = food.Quantity;
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
