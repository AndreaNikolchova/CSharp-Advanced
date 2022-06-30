using System;
using System.Collections.Generic;

namespace Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(' ');
            int n = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            foreach(string name in names)
            {
                queue.Enqueue(name);
            }
            while (queue.Count>1)
            {
                for (int i = 1; i < n; i++)
                {
                    string help = queue.Dequeue();
                    queue.Enqueue(help);
                }
              string name = queue.Dequeue();
              Console.WriteLine($"Removed {name}");
            }
            Console.WriteLine($"Last is {string.Join("", queue)}");
        }
    }
}
