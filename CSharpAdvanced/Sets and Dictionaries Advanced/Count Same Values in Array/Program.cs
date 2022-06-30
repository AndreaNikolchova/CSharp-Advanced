using System;
using System.Collections.Generic;

namespace Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary <string, int>();
            string[] line = Console.ReadLine().Split(" ");
            foreach(string s in line)
            {
                if (dictionary.ContainsKey(s))
                    dictionary[s]++;
                else  
                    dictionary.Add(s, 1);
            }
            foreach (string v in dictionary.Keys)
            {
                Console.WriteLine(v + " - " + dictionary[v] + " times");
            }
        }
    }
}
