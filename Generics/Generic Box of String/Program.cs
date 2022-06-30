using System;
using System.Collections.Generic;

namespace Generic_Box_of_String
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<string>> boxes = new List<Box<string>>();  
            for (int i = 1; i <=n; i++)
            {
                Box<string> box = new Box<string>(Console.ReadLine());
                boxes.Add(box);
            }
            foreach(Box<string> box in boxes)
                Console.WriteLine(box);

        }
    }
}
