using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Private> privates = new List<Private>();
            while (true)
            {
                string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (line[0] == "End")
                    break;
                switch (line[0])
                {
                    case "Private":
                        Private @private = new Private(line[1], line[2], line[3], decimal.Parse(line[4]));

                        Console.WriteLine(@private);

                        privates.Add(@private);

                        break;

                    case "Spy":
                        try
                        {
                            Spy spy = new Spy(line[1], line[2], line[3], int.Parse(line[4]));

                            Console.WriteLine(spy);

                        }
                        catch
                        {

                        }
                        break;

                    case "LieutenantGeneral":

                        LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(line[1], line[2], line[3], decimal.Parse(line[4]));

                        for (int i = 5; i < line.Length; i++)
                        {
                            Private currentPrivate = privates.FirstOrDefault(x => x.Id == line[i]);
                            if (currentPrivate != null)
                                lieutenantGeneral.Add(currentPrivate);
                        }

                        Console.WriteLine(lieutenantGeneral);

                        break;

                    case "Engineer":
                        try
                        {
                            Engineer engineer = new Engineer(line[1], line[2], line[3], decimal.Parse(line[4]), line[5]);

                            for (int i = 6; i < line.Length - 1; i += 2)
                                engineer.Add(new Repairs(line[i], int.Parse(line[i + 1])));

                            Console.WriteLine(engineer);
                        }
                        catch
                        {
                        }
                        break;

                    case "Commando":
                        try
                        {

                            Commando commando = new Commando(line[1], line[2], line[3], decimal.Parse(line[4]), line[5]);


                            for (int i = 6; i < line.Length - 1; i += 2)
                            {
                                try
                                {
                                    commando.Add(new Mission(line[i], line[i + 1]));
                                }
                                catch
                                { }
                            }


                            Console.WriteLine(commando);
                        }
                        catch
                        {
                        }

                        break;
                }

            }
        }
    }
}
