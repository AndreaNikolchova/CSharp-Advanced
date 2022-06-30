using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            ListyIterator<string> listyIterator = new ListyIterator<string>(list);
            while (true)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "END":
                        return;
                    case "Move":
                        Console.WriteLine(listyIterator.Move()); 
                        break;
                    case "Print":
                        listyIterator.Print();
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "Create":
                        string[] fillingTheList = command.Split(" ",StringSplitOptions.RemoveEmptyEntries).Where(x => x != "Create").ToArray();
                        list = fillingTheList.ToList();
                        listyIterator = new ListyIterator<string>(list);
                        break;
                }
            }
        }
    }
}
