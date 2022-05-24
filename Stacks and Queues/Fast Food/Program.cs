using System;
using System.Collections.Generic;
using System.Linq;

namespace Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>();
            Console.WriteLine(orders.Max());
            foreach (int order in orders)
            {
                if (order>quantity)
                {
                    queue.Enqueue(order);
                }
                quantity -= order;
            } 
            if (queue.Count>0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ",queue)}");
                return;
            }
            Console.WriteLine("Orders complete");

        }
    }
}
