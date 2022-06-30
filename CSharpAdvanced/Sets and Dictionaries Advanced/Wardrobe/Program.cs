using System;
using System.Collections.Generic;

namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,Dictionary<string,int>> wardrobe = new Dictionary<string,Dictionary<string,int>>();
            int n =  int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string[] color = Console.ReadLine().Split(" -> ");
                string[] clothes = color[1].Split(",");
                if (wardrobe.ContainsKey(color[0]))
                {
                    foreach(var type in clothes)
                    {
                        if (wardrobe[color[0]].ContainsKey(type))
                            wardrobe[color[0]][type]++;
                        else
                            wardrobe[color[0]].Add(type, 1);
                    }
                }
                else
                {
                    wardrobe.Add(color[0], new Dictionary<string, int>());
                    foreach (var type in clothes)
                    {
                        if (wardrobe[color[0]].ContainsKey(type))
                            wardrobe[color[0]][type]++;
                        else
                            wardrobe[color[0]].Add(type, 1);
                    }

                }
            }
            string[] item = Console.ReadLine().Split(" ");
            foreach(var thing in wardrobe)
            {
                Console.WriteLine(thing.Key + " clothes:");
                if (thing.Key == item[0])
                {
                    foreach (var s in thing.Value)
                    {
                        if (s.Key == item[1])
                            Console.WriteLine($"* {s.Key} - {s.Value} (found!)");
                        else
                            Console.WriteLine($"* {s.Key} - {s.Value}");
                    }
                }
                else
                {
                    foreach (var s in thing.Value)
                    {
                        Console.WriteLine($"* {s.Key} - {s.Value}");
                    }
                }
               
            }
        }
    }
}
