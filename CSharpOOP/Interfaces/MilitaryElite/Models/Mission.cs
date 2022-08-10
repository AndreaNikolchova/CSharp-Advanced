using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Mission
    {
        public string CodeName { get;private set;}

        private string state;
        public string State
        {
            get { return this.state; }
            private set 
            {
                if (value == "inProgress" || value == "Finished")
                    this.state = value;
                else
                    throw new InvalidOperationException("Non existing state!");
            }
        }
        public Mission(string name,string state)
        {
            this.CodeName = name;
            this.State = state;
        }
        public void CompleteMission()
        {
            this.State = "Finished";
        }
        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
