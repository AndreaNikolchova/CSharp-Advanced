using System;
using System.Collections.Generic;

namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Paid")
                {
                    foreach (var name in queue)
                    {
                        Console.WriteLine(name);
                    }
                    queue.Clear();
                }
                else if (line =="End")
                {
                    Console.WriteLine($"{queue.Count} people remaining.");
                    break;
                }
                else
                {
                    queue.Enqueue(line);
                }
            }
        }
    }
}
