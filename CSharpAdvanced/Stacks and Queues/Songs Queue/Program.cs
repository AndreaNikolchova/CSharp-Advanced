using System;
using System.Collections.Generic;

namespace Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");
            Queue<string> queue = new Queue<string>();
            string song =string.Empty;
            foreach (string son in songs)
                queue.Enqueue(son);
            while (queue.Count>0)
            {
                string line = Console.ReadLine();
                string[] command =line.Split(' ');
                switch (command[0])
                {
                    case "Play": 
                        queue.Dequeue();
                        break;
                    case "Add":
                        song = line.Substring(4, line.Length - 4);
                        if (queue.Contains(song)) 
                            Console.WriteLine($"{song} is already contained!");
                        else queue.Enqueue(song);
                           break;
                    case "Show": 
                        Console.WriteLine(string.Join(", ",queue));
                        break;
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
