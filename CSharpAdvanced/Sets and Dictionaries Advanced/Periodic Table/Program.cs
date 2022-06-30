using System;
using System.Collections.Generic;

namespace Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();
            for (int i = 1; i <= n; i++)
            {
                string[] line = Console.ReadLine().Split(" ");
                foreach(string s in line)
                    elements.Add(s);
            }
            Console.WriteLine(string.Join(" ",elements));
        }
    }
}
