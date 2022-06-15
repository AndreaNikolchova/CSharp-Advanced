using System;
using System.Collections.Generic;
using System.Linq;

namespace Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<char> input = Console.ReadLine().ToCharArray().ToList();
            Stack<char> stack = new Stack<char>();
            foreach (var item in input)
            {
                if (item == '{' || item == '[' || item == '(')
                    stack.Push(item);
                else if (item == '}' && stack.Count>0)
                {
                    char braket = stack.Peek();
                    if (braket == '{')
                        stack.Pop();
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (item == ']'&&stack.Count > 0)
                {
                    char braket = stack.Peek();
                    if (braket == '[')
                        stack.Pop();
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if(item == ')'&& stack.Count > 0)
                {
                    char braket = stack.Peek();
                    if (braket == '(')
                        stack.Pop();
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
               else
                {
                    Console.WriteLine("NO");
                    return;
                }    
                  
            }
            if (stack.Count>0)
            {
                Console.WriteLine("NO");
                return;
            }
            Console.WriteLine("YES");
        }
    }
}
