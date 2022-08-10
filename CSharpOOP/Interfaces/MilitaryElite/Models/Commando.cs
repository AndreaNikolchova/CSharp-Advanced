using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Models.Contracts;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, IComando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<Mission>();
        }
        private List<Mission> missions;
        public IReadOnlyCollection<Mission> Missions
        {
            get { return this.missions.AsReadOnly(); }
        }
        public void Add(Mission mission)
        {
            this.missions.Add(mission);
        }
       
        public override string ToString()
        {
            if (this.Missions.Count == 0)
                return base.ToString() + Environment.NewLine + $"Corps: {this.Corps}" + Environment.NewLine + "Missions:";
            else
                return base.ToString() + Environment.NewLine + $"Corps: {this.Corps}" + Environment.NewLine + "Missions:" + Environment.NewLine + "  " + String.Join(Environment.NewLine + "  ", this.missions);
        }
    }
}
