using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var set = new HashSet<string>();
            List<string> list = new List<string>();
            
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "PARTY") break;
                else set.Add(line);
            }
            while (true)
            {
                string command = Console.ReadLine();
                
                if (command=="END")
                {

                    foreach(var i in list)
                    {
                       if (set.Contains(i))
                       {
                           set.Remove(i);
                           
                       }   
                    }
                    list.Clear();
                    Console.WriteLine(set.Count);
                    foreach(var i in set)
                    {
                        if (char.IsDigit(i[0]))
                        {
                            list.Add(i);
                            
                        }
                         
                    }
                    foreach(var i in list)
                    {
                        if (set.Contains(i))
                        {
                            set.Remove(i);
                        }
                        Console.WriteLine(i);
                    }
                    foreach(var b in set)
                    {
                        Console.WriteLine(b);
                    }
                    return;
                   
                }
                list.Add(command);
            }
        }
    }
}
