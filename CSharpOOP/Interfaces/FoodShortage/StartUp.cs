using System;
using System.Collections.Generic;

namespace FoodShortage
{
    using Interfaces;
    using Classes;
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<IBuyer> buyers = new List<IBuyer>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                if (input.Length == 4)
                {
                    IBuyer citizen = new Citizens(input[0],int.Parse(input[1]),input[2],input[3]);
                    buyers.Add(citizen);
                }
                else
                {
                    IBuyer rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    buyers.Add(rebel);
                }
            }
            while (true)
            {
                string nameOfBuyer = Console.ReadLine();
                if (nameOfBuyer == "End")
                    break;
                int index = buyers.FindIndex(x => x.Name == nameOfBuyer);
                if (index != -1)
                   buyers[index].BuyFood();

            }
            int food = 0;
            foreach(var buy in buyers)
                food += buy.Food;
            Console.WriteLine(food);
        }
    }
}
