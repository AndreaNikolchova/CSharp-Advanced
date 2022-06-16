using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder s = new StringBuilder();
            Stack<string> stack = new Stack<string>();
            for (int i = 1; i <= n; i++)
            {
                string[] command = Console.ReadLine().Split();
                
                switch (command[0])
                {
                    case "1":
                        s.Append(command[1]);
                        stack.Push(s.ToString());
                        break;
                    case "2":
                        s.Remove(s.Length-int.Parse(command[1]), int.Parse(command[1]));
                        stack.Push(s.ToString());
                        break;
                    case "3":
                        Console.WriteLine(s[int.Parse(command[1])-1]);
                        break;
                    case "4":
                        stack.Pop();
                        s.Clear();
                        if (stack.Count>0)
                            s.Append(stack.Peek());
                        else
                            s.Clear();
                        break;
                }
            }
        }
    }
}
