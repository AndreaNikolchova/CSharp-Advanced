
namespace Formula1.Models
{
    using Formula1.Models.Contracts;
    using Formula1.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Race : IRace
    {
        public Race(string raceName, int numberOfLaps)
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
            this.pilots = new List<IPilot>();
            this.TookPlace = false;
        }
        private string raceName;
        public string RaceName
        {
            get { return this.raceName; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidRaceName, value));
                this.raceName = value; 
            }
        }
        private int numberOfLaps;
        public int NumberOfLaps
        {
            get { return this.numberOfLaps; }
            private set 
            {
                if(value<1)
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidLapNumbers, value));
                this.numberOfLaps = value; 
            }
        }

        private bool tookPlace;
        public bool TookPlace
        {
            get { return this.tookPlace; }
            set { this.tookPlace = value; }
        }

        private List<IPilot> pilots;

        public ICollection<IPilot> Pilots { get { return this.pilots; } }

        public void AddPilot(IPilot pilot)
        {
           this.pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            if(this.TookPlace)
                return $"The { this.RaceName } race has:{Environment.NewLine}Participants: { this.Pilots.Count }{Environment.NewLine}Number of laps: { this.NumberOfLaps}{Environment.NewLine}Took place: Yes";
            else
                return $"The { this.RaceName } race has:{Environment.NewLine}Participants: { this.Pilots.Count }{Environment.NewLine}Number of laps: { this.NumberOfLaps}{Environment.NewLine}Took place: No";
        }
    }
}
