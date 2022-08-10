using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Models.Contracts;
namespace MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary,string corps) : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }
        private string corps;
        public string Corps
        {
            get { return this.corps; }
            private set 
            {
                if (value == "Airforces" || value == "Marines")
                    this.corps = value;
                else
                    throw new InvalidOperationException("Invalid corps");
            }
        }

    }
}
