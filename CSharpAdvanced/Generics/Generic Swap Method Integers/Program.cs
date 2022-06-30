using System;
using System.Linq;

namespace Generic_Swap_Method_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();
            for (int i = 1; i <= n; i++)
                box.List.Add(int.Parse(Console.ReadLine()));

            int[] indexes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            box.Swap(indexes[0], indexes[1]);
            box.Print();
        }
    }
}
