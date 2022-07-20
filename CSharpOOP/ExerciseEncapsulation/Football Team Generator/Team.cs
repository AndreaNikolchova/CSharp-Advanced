namespace Football_Team_Generator
{
    using System.Collections.Generic;
    using System;
    public class Team
    {
        private readonly List<Player> players;
        private string name;
        private double rating;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public double Rating
        {
            get { return this.rating; }
            set { this.rating = value; }
        }
        public Team(string name)
        {
            this.Name = name;
            players = new List<Player>();
        }
        public void AddPlayer(string teamName,Player player)
        {
            if (this.Name == teamName)
            {
                players.Add(player);
            }
            else
            {
                throw new Exception($"Team {teamName} does not exist.");
            }
        }
        public void Remove(string teamName, string playerName)
        {
            if (this.Name == teamName)
            {
                foreach(var player in players)
                {
                    if (player.Name == playerName)
                    {
                        players.Remove(player);
                        return;
                    }
                }
                throw new Exception($"Player {playerName} is not in {teamName} team.");
            }
            else
            {
                throw new Exception($"Team {teamName} does not exist.");
            }

        }
        public void RatingPrint(Team team)
        {
            Console.WriteLine();
        }
    }
}
