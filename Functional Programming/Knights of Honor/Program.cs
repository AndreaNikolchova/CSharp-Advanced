using System;
using System.Collections.Generic;
using System.Linq;

namespace Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ').ToList();
            Action<List<string>> print = x => x.ForEach(t => Console.WriteLine("Sir " + t));
            print(input);
        }
    }
}
