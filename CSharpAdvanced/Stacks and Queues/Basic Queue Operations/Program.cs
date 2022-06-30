using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] specialNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            (int N,int S,int X) = (specialNumbers[0],specialNumbers[1],specialNumbers[2]);
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>();
            foreach(int n in numbers)
                queue.Enqueue(n);
            for (int i = 0; i < S; i++)
                queue.Dequeue();
            if (queue.Contains(X))
            {
                Console.WriteLine("true");
                return;
            }
            else
            {
                if (queue.Count>0)
                {
                    Console.WriteLine(queue.Min());
                    return;
                }
                Console.WriteLine(0);
            }
        }
    }
}
