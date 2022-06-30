using System;
using System.Linq;

namespace Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
           Stack<string> stack = new Stack<string>();
            string command = Console.ReadLine();
            while (command != "END")
            {
                if (command.StartsWith("Push"))
                {
                    string[] line = command.Split(new string[] { ", ", " " },StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
                    stack.Push(line);
                }
                if (command == "Pop")
                    stack.Pop();
                command = Console.ReadLine();
            }
            for (int i = 1; i <= 2; i++)
            {
                foreach(var item in stack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
