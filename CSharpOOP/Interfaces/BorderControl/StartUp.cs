using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> ids = new List<string>();
            while (true)
            {
                string[] line = Console.ReadLine().Split();
                if (line[0] == "End")
                    break;
                if (line.Length ==3)
                {
                    IPerson citizen = new Citizens(line[0],int.Parse(line[1]),line[2]);
                    ids.Add(citizen.Id);
                }
                else if (line.Length ==2)
                {
                    IRobot robot = new Robots(line[0], line[1]);
                    ids.Add(robot.Id);
                }
            }
            string endsWith = Console.ReadLine();
            foreach(string id in ids)
            {
                if (id.EndsWith(endsWith))
                    Console.WriteLine(id);
            }

        }
    }
}
