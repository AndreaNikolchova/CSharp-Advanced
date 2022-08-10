using MilitaryElite.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(string id,string firstName,string lastName)
        {
            this.Id = id;
            this.FistName = firstName;
            this.LastName = lastName;   
        }
        public string Id { get; private set; }

        public string FistName { get; private set; }

        public string LastName { get; private set; }
        public abstract override string ToString();
    }
}
