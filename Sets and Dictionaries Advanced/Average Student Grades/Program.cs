using System;
using System.Collections.Generic;
using System.Linq;

namespace Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, List<decimal>>();
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                string[] line = Console.ReadLine().Split(" ");
                if (dictionary.ContainsKey(line[0]))
                {
                    dictionary[line[0]].Add(decimal.Parse(line[1]));
                }
                else
                {
                    dictionary.Add(line[0], new List<decimal>(){decimal.Parse(line[1])});
                }

            }
            foreach (var st in dictionary.Keys)
            {
                Console.Write($"{st} -> ");
                foreach (var gr in dictionary[st])
                {
                    Console.Write($"{gr:0.00} ");
                }
                Console.Write($"(avg: {Math.Round(dictionary[st].Average(), 2, MidpointRounding.AwayFromZero):0.00})");
                Console.WriteLine();
            }
        }
    } 
}
