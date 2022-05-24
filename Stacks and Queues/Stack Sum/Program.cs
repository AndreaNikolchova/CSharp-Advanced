using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int[] firstNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            foreach(int number in firstNumbers)
            {
                stack.Push(number);
            }
            while (true)
            {
                string[] command = Console.ReadLine().ToLower().Split(' ').ToArray();
                if (command[0]=="add")
                {
                    int n1 = int.Parse(command[1]);
                    int n2 = int.Parse(command[2]);
                    stack.Push(n1);
                    stack.Push(n2);
                }
                else if (command[0]=="remove")
                {
                    int n = int.Parse(command[1]);
                    if (stack.Count-n>0)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                else if (command[0]=="end")
                {
                    Console.WriteLine($"Sum: {stack.Sum()}");
                    break;
                }

            }
        }
    }
}
