using System;
using System.Collections.Generic;

namespace Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var set = new HashSet<string>();
            while (true)
            {
                string[] line = Console.ReadLine().Split(", ");
                if (line[0] == "END")
                {
                    if (set.Count > 0)
                    {
                        foreach (var item in set)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Parking Lot is Empty");
                    }
                    return;
                }
                if (line[0] == "IN")
                {
                    set.Add(line[1]);
                }
                if (line[0] == "OUT")
                {
                    set.Remove(line[1]);
                }
            }
        }
    }
}
