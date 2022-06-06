using System;
using System.Linq;

namespace Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(" ");
            Func<string, int, bool> filter = (x, y) => x.Length <= y;
            Func<string[], Func<string, int, bool>, string[]> final = (x, y) => x.Where(t => y(t,lenght)).ToArray();
            input = final(input, filter);
            Array.ForEach(input, x => Console.WriteLine(x));
            
        
        }
    }
}
