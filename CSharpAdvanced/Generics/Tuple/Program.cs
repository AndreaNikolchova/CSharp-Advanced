using System;

namespace Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] line1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] line2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] line3 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Tuple<string, string> line1Tuple = new Tuple<string, string>(line1[0]+ " "+ line1[1],line1[2]);
            Tuple<string, int> line2Tuple = new Tuple<string, int>(line2[0], int.Parse(line2[1]));
            Tuple<int, double> line3Tuple = new Tuple<int,double>(int.Parse(line3[0]), double.Parse(line3[1]));
            Console.WriteLine(line1Tuple);
            Console.WriteLine(line2Tuple);
            Console.WriteLine(line3Tuple);
        }
    }
}
