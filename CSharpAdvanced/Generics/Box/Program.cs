using System;
using System.Collections.Generic;

namespace Box
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<int>> boxes = new List<Box<int>>();
            for (int i = 1; i <= n; i++)
            {
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
                boxes.Add(box);
            }
            foreach (Box<int> box in boxes)
                Console.WriteLine(box);
        }
    }
}
