using System;
using System.Collections.Generic;
using System.Linq;

namespace Collection
{
    public class Program
    {
        static void Main(string[] args)
        { 
            ListyIterator<string> listy = new ListyIterator<string>(Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Skip(1).ToList());
            while (true)
            {
                string[] command = Console.ReadLine().Split(" ");
                switch (command[0])
                {
                    case "END":
                        return;
                    case "Move":
                        Console.WriteLine(listy.Move());
                        break;
                    case "Print":
                        listy.Print();
                        break;
                    case "HasNext":
                        Console.WriteLine(listy.HasNext());
                        break;
                    case "PrintAll":
                        listy.PrintAll();
                        break;
                }
            }
        }
    }
}
