
namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    public class Battleship : Vessel, IBattleship
    {
        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 300)
        {
            this.SonarMode = false;
        }
        public bool SonarMode { get; private set; }
        public override void RepairVessel()
        {
            this.ArmorThickness = 300;
        }

        public void ToggleSonarMode()
        {
            if (this.SonarMode == false)
            {
                this.SonarMode = true;
                base.MainWeaponCaliber += 40;
                base.Speed -= 5;
            }
            else
            {
                this.SonarMode = false;
                base.MainWeaponCaliber -= 40;
                base.Speed += 5;
            }
        }
        public override string ToString()
        {
            if(this.SonarMode)
            return base.ToString() + $"{Environment.NewLine} *Sonar mode: ON";
            else
                return base.ToString() + $"{Environment.NewLine} *Sonar mode: OFF";

        }
    }
}
