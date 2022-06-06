using System;
using System.Collections.Generic;
using System.Linq;

namespace Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ').ToList();
            Action<List<string>> print = x => x.ForEach(t=>Console.WriteLine(t));
            print(input);
        }
    }
}
