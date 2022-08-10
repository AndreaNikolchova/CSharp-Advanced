using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Models.Contracts;

namespace MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName,int codeNumber) : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            return $"Name: {this.FistName} {this.LastName} Id: {this.Id}{Environment.NewLine}Code Number: {this.CodeNumber}";
        }
    }
}
