using System;
using System.Collections.Generic;
using System.Linq;

namespace Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> numbers = new Dictionary<string, int>();
            for (int i = 1; i <= n; i++)
            {
                string line = Console.ReadLine();
                if (numbers.ContainsKey(line))
                    numbers[line]++;
                else
                    numbers.Add(line, 1);
            }
            Console.WriteLine(numbers.First(x=>x.Value%2==0).Key);
        }
    }
}
