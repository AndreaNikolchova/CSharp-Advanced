using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] line = Console.ReadLine()
                                .Split(" ")
                                .Select(int.Parse)
                                .ToArray();
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            for(int i=1; i <=line[0]; i++)
                firstSet.Add(int.Parse(Console.ReadLine()));
            for (int i = 1; i <= line[1]; i++)
                secondSet.Add(int.Parse(Console.ReadLine()));
            firstSet.IntersectWith(secondSet);
            Console.WriteLine(string.Join(" ",firstSet));
        }
    }
}
