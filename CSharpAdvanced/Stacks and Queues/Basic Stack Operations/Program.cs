using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] specialNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            (int N,int S,int X) = (specialNumbers[0],specialNumbers[1],specialNumbers[2]);
            Stack<int> stack = new Stack<int>();
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            foreach (var number in arr)
                stack.Push(number);
            for (int i = 0; i < S; i++)
                stack.Pop();
            if (stack.Contains(X))
            {
                Console.WriteLine("true");
                return;
            }
            else
            {
                if (stack.Count>0)
                {
                    int minValue = int.MaxValue;
                    foreach (var number in stack)
                    {
                        if (number < minValue)
                        {
                            minValue = number;
                        }
                    }
                    Console.WriteLine(minValue);
                    return;
                }
                Console.WriteLine(0);
            }
        }
    }
}
