using System;

namespace Threeuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] line1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] line2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] line3 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Threeuple<string, string,string> line1Tuple = new Threeuple<string, string,string>(line1[0] + " " + line1[1], line1[2],line1[3]);
            Threeuple<string, int, bool> line2Tuple = new Threeuple<string, int, bool>(line2[0], int.Parse(line2[1]), true);
            if (line2[2]=="drunk")
            {
                line2Tuple = new Threeuple<string, int, bool>(line2[0], int.Parse(line2[1]), true);
            }
            else
            {
               line2Tuple = new Threeuple<string, int, bool>(line2[0], int.Parse(line2[1]), false);
            }
            Threeuple<string, double,string> line3Tuple = new Threeuple<string, double, string>(line3[0], double.Parse(line3[1]),line3[2]);
            Console.WriteLine(line1Tuple);
            Console.WriteLine(line2Tuple);
            Console.WriteLine(line3Tuple);
        }
    }
}
