using System;
using System.Collections.Generic;
using System.Linq;

namespace Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
             int[] thingsInABox = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
             int capasityOfTheRack = int.Parse(Console.ReadLine()); 
             Stack<int> stack = new Stack<int>();
            foreach(int thing in thingsInABox)
                stack.Push(thing);
            int sum = 0;
            int countOfRacks = 1;
            while (stack.Count>0)
            {
                if (sum + stack.Peek() > capasityOfTheRack)
                {
                    sum = stack.Pop();
                    countOfRacks++;
                }
                else
                   sum+=stack.Pop();
            }
            Console.WriteLine(countOfRacks);
        }
    }
}
