using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Generic_Swap_Method_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();
            for (int i = 1; i <= n; i++)
                 box.List.Add(Console.ReadLine());

            int[] indexes = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            box.Swap(indexes[0], indexes[1]);
            box.Print();
        }
    }
}
