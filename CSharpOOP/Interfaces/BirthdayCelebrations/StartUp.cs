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
            List<string> dates = new List<string>();
            while (true)
            {
                string[] line = Console.ReadLine().Split();
                if (line[0] == "End")
                    break;
                if (line.Length == 5)
                {
                    IBirthable citizen = new Citizens(line[1], int.Parse(line[2]), line[3],line[4]);
                    dates.Add(citizen.Birthdate);
                }
                else if (line.Length == 3)
                {
                    if (line[0]!="Robot")
                    {
                        IPet pet = new Pet(line[1], line[2]);
                        dates.Add(pet.Birthdate);
                    }
                }
            }
            string endsWith = Console.ReadLine();
            foreach (string date in dates)
            {
                if (date.EndsWith(endsWith))
                    Console.WriteLine(date);
              
            }
            

        }
    }
}
