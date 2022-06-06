using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<string> people = Console.ReadLine().Split(' ').ToList();
            string[] copy = people.ToArray();
            while (true)
            {
                string[] command = Console.ReadLine().Split(' ');
                Predicate<string> startsWith = x => x.StartsWith(command[2]);
                Predicate<string> endsWith = x => x.EndsWith(command[2]);
                Predicate<string> lenght = x => x.Length == int.Parse(command[2]);
                if (command[0] == "Party!")
                {
                    if (people.Count>0)
                        Console.WriteLine(String.Join(", ",people) + " are going to the party!");
                    else
                        Console.WriteLine("Nobody is going to the party!");
                    return;
                }
                else if (command[0] == "Double")
                {
                    switch (command[1])
                    {
                        case "StartsWith":
                            Array.ForEach(copy, x =>add(people,x,startsWith));
                            break;
                        case "EndsWith":
                            Array.ForEach(copy, x => add(people, x, endsWith));
                            break;
                        case "Length":
                            Array.ForEach(copy,x => add(people, x, lenght));
                            break;
                    }

                }
                else if (command[0] == "Remove")
                {
                    switch (command[1])
                    {
                        case "StartsWith":
                            people.RemoveAll(startsWith);
                            break;
                        case "EndsWith":
                            people.RemoveAll(endsWith);
                            break;
                        case "Length":
                            people.RemoveAll(lenght);
                            break;
                    }
                }
                copy = people.ToArray();
            }
        }
        
        static void add(List<string> people,string x , Predicate<string> func)
        {
            if (func(x))
            {
                int index =  people.IndexOf(x);
                people.Insert(index,x);
            }
        }
        
    }
}
