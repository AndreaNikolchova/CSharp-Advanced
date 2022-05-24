using System;
using System.Collections.Generic;

namespace Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            int countOfCarsPassed = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "green")
                {
                    for (int i = 1; i <= n; i++)
                    {
                        if (queue.Count > 0)
                        {
                            string name = queue.Dequeue();
                            Console.WriteLine($"{name} passed!");
                            countOfCarsPassed++;
                        }
                    }
                }
                else if (command == "end")
                {
                    Console.WriteLine($"{countOfCarsPassed} cars passed the crossroads.");
                    break;
                }
                else
                {
                    queue.Enqueue(command);
                }
            }
        }
    }
}
