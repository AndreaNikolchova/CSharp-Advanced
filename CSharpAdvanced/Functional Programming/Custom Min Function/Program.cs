using System;
using System.Collections.Generic;
using System.Linq;

namespace Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            Func<List<int>,int> func = x =>x.Min();
            Console.WriteLine(func(input));
        }
    }
}
