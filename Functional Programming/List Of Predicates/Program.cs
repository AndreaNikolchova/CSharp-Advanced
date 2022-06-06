using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            int[] array = new int[end];
            int[] dividers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int i = 1; i <=end; i++)
                array[i-1] = i;
            Func<int, int, bool> ifItIsDivisable = (x, y) => x % y == 0;
            List<int> answer = new List<int>();
            int count = 0;
            foreach(var number in array)
            {
                foreach(var digit in dividers)
                {
                    if (ifItIsDivisable(number,digit))
                    {
                        count++;
                    }
                   
                }
                if (count == dividers.Length)
                {
                    answer.Add(number); 
                }
                count = 0;
            }
            Console.WriteLine(String.Join(" ",answer));
        }
        
    }
}
