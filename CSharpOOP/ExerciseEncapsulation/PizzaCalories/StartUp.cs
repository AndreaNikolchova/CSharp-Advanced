using System;

namespace PizzaCalories
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            Pizza pizza = null;
            while (true)
            {
                string[] array = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                if (array[0] == "END")
                {
                    break;
                }
                try
                {
                    if (array[0] == "Pizza")
                    {
                        pizza = new Pizza(array[1]);

                    }
                    else if (array[0] == "Dough")
                    { 
                        Dough dough = new Dough(array[1], array[2], int.Parse(array[3]));
                        pizza.Dough = dough;
                    }
                    if (array[0]=="Topping")
                    {
                        if (pizza.Count>10)
                            throw new Exception("Number of toppings should be in range [0..10].");
                        else
                            pizza.AddTopings(new Topping(array[1],int.Parse(array[2])));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
               
            }
            Console.WriteLine(pizza);
        }
    }
}
