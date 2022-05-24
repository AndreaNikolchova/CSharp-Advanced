using System;
using System.Collections.Generic;

namespace Record_Unique_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int n = int.Parse(Console.ReadLine());
            var set = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                set.Add(Console.ReadLine());
            }
            foreach(string s in set)
            {
                Console.WriteLine(s);
            }
        }
    }
}
