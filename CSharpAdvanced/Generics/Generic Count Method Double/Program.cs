using System;
using System.Collections.Generic;

namespace Generic_Count_Method_Double
{
    public class Program
    {
        static void Main(string[] args)
        {
            var numberOfLine = int.Parse(Console.ReadLine());
            var list = new List<double>();
            for (int i = 0; i < numberOfLine; i++)
            {
                var input = double.Parse(Console.ReadLine());
                list.Add(input);
            }

            var box = new Box<double>(list);
            var elementToCompare = double.Parse(Console.ReadLine());
            var count = box.CountOFGreaterElements(list, elementToCompare);
            Console.WriteLine(count);
        }
    }
}
