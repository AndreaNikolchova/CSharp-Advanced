using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Repairs
    {
        public string PartName { get; private set; }
        public int WorkedHours { get; private set; }
        public Repairs(string partName, int WorkedHours)
        {
            this.PartName = partName;
            this.WorkedHours = WorkedHours;
        }
        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.WorkedHours}";
        }
    }
}
