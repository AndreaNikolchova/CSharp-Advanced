using System;
using System.Collections.Generic;
using System.Linq;

namespace Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            Func<List<int>, List<int>> add = x => x.Select(t=>t+=1).ToList();
            Func<List<int>, List<int>> multiply = x => x.Select(t => t*= 2).ToList();
            Func<List<int>, List<int>> subtract = x => x.Select(t => t -= 1).ToList();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                    break;
                else if (command == "print")
                    Console.WriteLine(String.Join(' ', input));
                else if (command == "add")
                    input= add(input);
                else if (command == "multiply")
                    input= multiply(input);
                else if (command == "subtract")
                    input = subtract(input);
                
            }
        }
    }
}
