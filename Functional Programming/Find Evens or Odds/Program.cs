using System;
using System.Linq;

namespace Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int startIndex = input[0];
            int endIndex = input[1];
            string filterString = Console.ReadLine();
            
            for (int i = startIndex; i <= endIndex; i++)
            {
                Func<int, bool> predicate = checkNumber(filterString, i);
                if (predicate(i))
                {
                    Console.Write(i + " ");
                }
            }

            
        }
        static Func<int,bool> checkNumber(string fiter,int number)
        {
            if (fiter == "odd")
                return x => x % 2 != 0;
            else 
                return x => x % 2 == 0;
        }
    }
}
