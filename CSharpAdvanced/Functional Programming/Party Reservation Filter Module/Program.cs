using System;
using System.Collections.Generic;
using System.Linq;

namespace Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(' ').ToList();
            List<string> commands = new List<string>();
            while (true)
            {
                string[] command = Console.ReadLine().Split(';');
                if (command[0] == "Print")
                    break;
                else if (command[0] == "Add filter")
                    commands.Add(command[1] + ";" + command[2]);
                else if (command[0] == "Remove filter")
                    commands.Remove(command[1] + ";" + command[2]);
            }
            foreach(var s in commands)
            {
                string[] command= s.Split(";"); 
                 Predicate<string> startsWith = x => x.StartsWith(command[1]);
                 Predicate<string> endsWith = x => x.EndsWith(command[1]);
                 Predicate<string> lenght = x => x.Length == int.Parse(command[1]);
                Predicate<string> contains = x => x.Contains(command[1]);
                switch (command[0])
                {
                    case "Starts with":
                        people.RemoveAll(startsWith);
                        break;
                    case "Ends with":
                        people.RemoveAll(endsWith);
                        break;
                    case "Length":
                        people.RemoveAll(lenght);
                        break;
                    case "Contains":
                        people.RemoveAll(contains);
                        break;
                }
            }
            Console.WriteLine(String.Join(" ",people));

        }
    }
}
