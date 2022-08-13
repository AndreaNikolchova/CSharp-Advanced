using System;
using System.Collections.Generic;

namespace Football_Team_Generator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] line = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                if (line[0] == "END")
                    break;
                if(line[0] == "Team")
                {

                }
            }
        }

    }
}
