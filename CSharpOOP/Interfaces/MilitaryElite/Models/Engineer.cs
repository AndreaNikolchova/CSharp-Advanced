using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Models.Contracts;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<Repairs>(); 
        }
        private List<Repairs> repairs;
        public IReadOnlyCollection<Repairs> Repairs
        {
            get { return this.repairs.AsReadOnly(); }
        }
        public void Add(Repairs repair)
        {
            this.repairs.Add(repair);
        }
        public override string ToString()
        {
            if (this.Repairs.Count == 0)
                return base.ToString() + Environment.NewLine + $"Corps: {this.Corps}" + Environment.NewLine + "Repairs:";
            else
                return base.ToString() + Environment.NewLine + $"Corps: {this.Corps}" + Environment.NewLine + "Repairs:" + Environment.NewLine + "  " + String.Join(Environment.NewLine + "  ", this.repairs);
        }
    }
}
