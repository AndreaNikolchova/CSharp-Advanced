using System;
using System.Collections.Generic;

namespace Truck_Tour
{
    internal class Program
    {
        class Pumps
        {
            public long Liters { get; set; }
            public long Distance  { get; set; }
            public Pumps (long liters, long distance)
            {
                this.Liters = liters;
                this.Distance = distance;
            }

        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); 
            Queue<Pumps> queue = new Queue<Pumps>();
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(" ");
                queue.Enqueue(new Pumps(long.Parse(line[0]), long.Parse(line[1])));
            }


        }
    }
}
