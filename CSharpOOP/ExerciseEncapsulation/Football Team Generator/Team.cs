namespace Football_Team_Generator
{
    using System.Collections.Generic;
    using System;
    public class Team
    {
        private readonly List<Player> players;
        private string name;
        private decimal rating;
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("A name should not be empty.");
                this.name = value;
            }
        }
        public decimal Rating
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

        public void RatingPrint()
        {
            foreach(Player player in players)
            {
                this.Rating =  this.Rating + player.Raiting();
            }
            if (players.Count != 0)
            {
                this.Rating = this.Rating / players.Count;
            }
            Console.WriteLine($"{this.Name} - {Math.Round(this.Rating,MidpointRounding.AwayFromZero)}");
        }
    }
}
