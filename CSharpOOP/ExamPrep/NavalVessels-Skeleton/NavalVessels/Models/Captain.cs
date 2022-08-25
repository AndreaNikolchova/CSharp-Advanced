
namespace NavalVessels.Models.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Utilities.Messages;
    public class Captain : ICaptain
    {
        public Captain(string fullName)
        {
            this.FullName = fullName;
            this.CombatExperience = 0;
            this.vessels = new List<IVessel>();
        }
        private string fullName;
        public string FullName
        {
            get { return this.fullName; }
            private set 
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                this.fullName = value;
            }
        }

        public int CombatExperience
        { get; private set; }

        private List<IVessel> vessels;
        public ICollection<IVessel> Vessels
        {
            get { return this.vessels.AsReadOnly(); }
        }
        public void AddVessel(IVessel vessel)
        {
           if(vessel == null)
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
           else
                this.vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.FullName} has {this.CombatExperience} combat experience and commands {this.Vessels.Count} vessels.");
            if(this.vessels.Count > 0)
            {
                foreach(var vessel in this.vessels)
                {
                    sb.AppendLine(vessel.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
