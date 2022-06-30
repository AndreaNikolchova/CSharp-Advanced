using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> arr = Console.ReadLine().Split(' ').ToArray().ToList();
            arr.Reverse();
            int sum = 0;
            Stack<string> stack = new Stack<string>();
            string m = String.Empty;
            foreach (string s in arr)
            {
                stack.Push(s);
            }
            for (int i = 0; i < stack.Count; i++)
            {

                string n = stack.Pop();
                if (m == "-")
                {
                    sum -= int.Parse(n);
                }
                else if (m == "+" || m == "")
                {
                    sum+=int.Parse(n);
                }
                i--;
                if (stack.Count>0)
                {
                    m = stack.Pop();
                }
                
            }
            Console.WriteLine(sum);
            
        }
    }
}
