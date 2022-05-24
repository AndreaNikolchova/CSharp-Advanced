using System;
using System.Collections.Generic;

namespace Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string line  = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            int startIndex = 0;
            List<string> list = new List<string>();
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '(')
                {
                    stack.Push(i);
                }
                else if (line[i] == ')')
                {
                    startIndex = stack.Pop();
                    Console.WriteLine(line.Substring(startIndex, i - startIndex + 1));
                }
            }
        }
    }
}
