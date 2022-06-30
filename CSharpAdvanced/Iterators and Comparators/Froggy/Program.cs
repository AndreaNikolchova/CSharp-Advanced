using System;

namespace Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            Lake lake = new Lake();
            string[] line = Console.ReadLine().Split(", ");
            lake.FillTheArray(line);
            Console.WriteLine(String.Join(", ",lake));
        }
    }
}
