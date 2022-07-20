
namespace Football_Team_Generator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }
        public int Endurance
        {
            get { return endurance; }
            private set { endurance = value; }
        }
        public int Sprint
        {
            get { return sprint; }
            private set { sprint = value; }
        }
        public int Dribble
        {
            get { return dribble; }
            private set { dribble = value; }
        }
        public int Passing
        {
            get { return passing; }
            private set { passing = value; }
        }
        public int Shooting
        {
            get { return shooting; }
            private set { shooting = value; }
        }
        internal double Raiting()
        {
            return ( this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5;
        }

    }
}
