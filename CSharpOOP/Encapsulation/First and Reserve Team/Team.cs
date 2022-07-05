using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;
        public string Name 
        { 
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public IReadOnlyCollection<Person> FirstTeam { get { return this.firstTeam.AsReadOnly(); } }
        public IReadOnlyCollection<Person> ReserveTeam { get { return this.reserveTeam.AsReadOnly(); } }

        public Team(string name)
        {
            this.Name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }
        public void AddPlayer(Person person)
        {
            if (person.Age<40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
        public override string ToString()
        {
            return $"First team has {this.FirstTeam.Count} players.{Environment.NewLine}Reserve team has {this.ReserveTeam.Count} players.";
        }
    }
}
