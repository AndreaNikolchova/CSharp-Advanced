using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shop = new Dictionary<string, Dictionary<string, double>>();
            while (true)
            {
                string[] line = Console.ReadLine().Split(", ");
                if (line[0] == "Revision")
                {
                    foreach (var k in shop.Keys.OrderBy(x => x))
                    {
                        Console.WriteLine($"{k}->");
                        foreach (var (thing,price) in shop[k])
                        {
                            Console.WriteLine($"Product: {thing}, Price: {price}");
                        }
                       
                    }
                    return;

                }
                if (shop.ContainsKey(line[0]))
                {
                    if (shop[line[0]].ContainsKey(line[1]))
                    {
                        shop[line[0]][line[1]] = double.Parse(line[2]);
                    }
                    else
                    {
                        shop[line[0]].Add(line[1], double.Parse(line[2]));
                    }
                }
                else
                {
                    shop.Add(line[0], new Dictionary<string, double>());
                    shop[line[0]].Add(line[1], double.Parse(line[2]));
                }
            }
        }
    }
}
