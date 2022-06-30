using System;
using System.Collections.Generic;

namespace Box
{
    public class Program
    {
        static void Main(string[] args)
        {
            var numberOfLine = int.Parse(Console.ReadLine());
            var list = new List<string>();
            for (int i = 0; i < numberOfLine; i++)
            {
                var input = Console.ReadLine();
                list.Add(input);
            }
            var box = new Box<string>(list);
            var elementToCompare = Console.ReadLine();
            var count = box.CountOFGreaterElements(list, elementToCompare);
            Console.WriteLine(count);
        } 
    }
}    

