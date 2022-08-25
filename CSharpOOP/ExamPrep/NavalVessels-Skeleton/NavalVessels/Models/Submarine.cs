
namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    public class Submarine : Vessel, ISubmarine
    {
        public Submarine(string name, double mainWeaponCaliber, double speed ) : base(name, mainWeaponCaliber, speed, 200)
        {
            this.SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }

        public override void RepairVessel()
        {
            base.ArmorThickness = 200;
        }

        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode == false)
            {
                this.SubmergeMode = true;
                base.MainWeaponCaliber += 40;
                base.Speed -= 4;
            }
            else
            {
                this.SubmergeMode = false;
                base.MainWeaponCaliber -= 40;
                base.Speed += 4;
            }
        }
        public override string ToString()
        {
            if (this.SubmergeMode)
                return base.ToString() + $"{Environment.NewLine} *Submerge mode:  ON";
            else
                return base.ToString() + $"{Environment.NewLine} *Submerge mode:  OFF";

        }
    }
}
