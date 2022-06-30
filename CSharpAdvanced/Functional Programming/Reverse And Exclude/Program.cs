using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Func<int[], int[]> reverse = x => x.Reverse().ToArray();
            input = reverse(input);
            int numberToDivise= int.Parse(Console.ReadLine());
            Func<int[],int[]> finalNumbers= x=> x.Where(y=>y%numberToDivise!=0).ToArray();
            Console.WriteLine(String.Join(" ",input= finalNumbers(input)));
        }
    }
}
