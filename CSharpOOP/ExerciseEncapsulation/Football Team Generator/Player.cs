
namespace Football_Team_Generator
{
    using System;
    public class Player
    {
        public Player(string name,int endurance,int sprint, int dribble,int passing,int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public string Name
        {
            get { return this.name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("A name should not be empty.");
                this.name = value;
            }
        }
        public int Endurance
        {
            get { return endurance; }
            private set 
            {
                if (value<0||value>100)
                    throw new Exception($"Endurance should be between 0 and 100.");
                this.endurance = value;
            }
        }
        public int Sprint
        {
            get { return sprint; }
            private set 
            {
                if (value < 0 || value > 100)
                    throw new Exception($"Sprint should be between 0 and 100.");
                this.sprint = value; 
            }
        }
        public int Dribble
        {
            get { return dribble; }
            private set 
            {
                if (value < 0 || value > 100)
                    throw new Exception($"Dribble should be between 0 and 100.");
                this.dribble = value; 
            }
        }
        public int Passing
        {
            get { return passing; }
            private set 
            {
                if (value < 0 || value > 100)
                    throw new Exception($"Passing should be between 0 and 100.");
                this.passing = value;
            }
        }
        public int Shooting
        {
            get { return shooting; }
            private set 
            {
                if (value < 0 || value > 100)
                    throw new Exception($"Shooting should be between 0 and 100.");
                this.shooting = value; 
            }
        }
        public decimal Raiting()
        {
            decimal sum = this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting;
            decimal round = sum / 5;
            return Math.Round(round);
        }

    }
}
