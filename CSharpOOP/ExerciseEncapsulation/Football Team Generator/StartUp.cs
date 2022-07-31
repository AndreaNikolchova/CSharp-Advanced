using System;

namespace Football_Team_Generator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Team team = null;
            while (true)
            {
                string[] input = Console.ReadLine().Split(';');
                if (input[0] == "END")
                    break;
                if (input.Length == 2&& input[0]!="Rating")
                {
                    team = new Team(input[1]);
                }
                else
                {
                    if (input[0] == "Add")
                    {
                        try
                        {
                            Player player = new Player(input[2], int.Parse(input[3]), int.Parse(input[4]), int.Parse(input[5]), int.Parse(input[6]), int.Parse(input[7]));
                            team.AddPlayer(input[1], player);
                        }
                        catch (Exception ex)
                        { Console.WriteLine(ex.Message); }
                    }
                    else if (input[0] == "Remove")
                    {
                        try
                        {
                            team.Remove(input[1],input[2]);
                        }
                        catch(Exception ex)
                        { Console.WriteLine(ex.Message); }
                    }
                    else if( input[0] == "Rating")
                    {
                        team.RatingPrint();
                    }

                }


            }
        }
    }
}
