using System;
using System.Collections.Generic;
using System.Linq;

namespace Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            foreach(int i in arr)
            {
                if (i%2==0)
                {
                    queue.Enqueue(i);
                }
            }
            Console.WriteLine(string.Join(", ",queue));
        }
    }
}
