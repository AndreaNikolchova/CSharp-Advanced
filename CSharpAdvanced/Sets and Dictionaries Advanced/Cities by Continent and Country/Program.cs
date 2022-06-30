using System;
using System.Collections.Generic;

namespace Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string,Dictionary<string,List<string>>>();
            for(int i = 1; i <= n; i++)
            {
                string[] line = Console.ReadLine().Split(" ");
                if (dict.ContainsKey(line[0]))
                {
                    if (dict[line[0]].ContainsKey(line[1]))
                    {
                        dict[line[0]][line[1]].Add(line[2]);
                    }
                    else
                    {
                        dict[line[0]].Add(line[1],new List<string> { line[2] });
                    }
                }
                else
                {
                    dict.Add(line[0], new Dictionary<string, List<string>>());
                    dict[line[0]].Add(line[1], new List<string> { line[2] });
                }
            }
            foreach(string key in dict.Keys)
            {
                Console.WriteLine(key+ ":");
                foreach(var (contry,city) in dict[key])
                {
                    Console.WriteLine(contry + " -> " + String.Join(", ",city));
                }
            }
        }
    }
}
