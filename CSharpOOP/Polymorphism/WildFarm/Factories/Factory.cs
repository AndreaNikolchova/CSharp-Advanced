namespace WildFarm.Factories
{
    using Models;
    using Models.TypeOfAnimals.TypeOfBirds;
    using WildFarm.Models.TypeOfAnimals;
    using WildFarm.Models.TypeOfAnimals.TypeOfMammals;
    using WildFarm.Models.TypeOfAnimals.TypeOfMammals.TypeOfFelines;
    using WildFarm.Models.TypeOfFoods;

    public class Factory
    {
        public Animal CreateAnimal(string[] line)
        {
            switch(line[0])
            {
                case "Hen":
                    Animal hen = new Hen(line[1], double.Parse(line[2]), double.Parse(line[3]));
                    return hen;
                case "Owl":
                    Animal olw = new Owl(line[1], double.Parse(line[2]), double.Parse(line[3]));
                    return olw;
                case "Cat":
                    Animal cat = new Cat(line[1], double.Parse(line[2]),line[3],line[4]);
                    return cat;
                case "Tiger":
                    Animal tiger = new Tiger(line[1], double.Parse(line[2]), line[3], line[4]);
                    return tiger;
                case "Dog":
                    Animal dog = new Dog(line[1], double.Parse(line[2]), line[3]);
                    return dog;
                case "Mouse":
                    Animal mouse = new Mouse(line[1], double.Parse(line[2]), line[3]);
                    return mouse;
                default:
                    return null;
            }
        }
        public Food CreateFood(string[] line)
        {
            switch (line[0])
            {
                case "Vegetable":
                    Food vegetable = new Vegetable(int.Parse(line[1]));
                    return vegetable;
                case "Fruit":
                    Food fruit = new Fruit(int.Parse(line[1]));
                    return fruit;
                case "Meat":
                    Food meat = new Meat(int.Parse(line[1]));
                  return meat;
                case "Seeds":
                    Food seeds = new Seeds(int.Parse(line[1]));
                    return seeds;
                default:
                    return null;
            }

        }
    }
}
