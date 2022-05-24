using System;
using System.Collections.Generic;

namespace _1._Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>();  
            string line = Console.ReadLine();
            foreach (var ch in line)
            {
                stack.Push(ch);
            }
            Console.WriteLine(string.Join("",stack));
        }
    }
}
