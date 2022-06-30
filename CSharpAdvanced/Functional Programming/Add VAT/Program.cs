using System;
using System.Linq;

namespace Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<decimal, decimal> addVAT = x => Math.Round(x * 1.20m, 2);
            decimal[] array = Console.ReadLine().Split(", ").Select(decimal.Parse).Select(addVAT).ToArray();
            Console.WriteLine("{0:f2}",String.Join("\r\n",array));
           
        }
    }
}
