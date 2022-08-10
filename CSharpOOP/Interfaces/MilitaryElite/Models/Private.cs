﻿using MilitaryElite.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(string id, string firstName,string lastName,decimal salary) :base(id,firstName,lastName)
        {
            this.Salary = salary;
        }
        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"Name: {this.FistName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}";
        }
    }
}
