
namespace NavalVessels.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using NavalVessels.Models;
    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories;
    using Utilities.Messages;

    public class Controller : IController
    {
        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new List<ICaptain>();
        }
        private VesselRepository vessels;
        private List<ICaptain> captains;
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            if (!this.captains.Select(x => x.FullName).Contains(selectedCaptainName))
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            else if (this.vessels.FindByName(selectedVesselName) == null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            else
            {
                if (this.vessels.FindByName(selectedVesselName).Captain != null)
                {
                    return String.Format(OutputMessages.VesselOccupied, selectedVesselName);
                }
                else
                {
                    var captain = this.captains.FirstOrDefault(x => x.FullName == selectedCaptainName);
                    var vessel = this.vessels.FindByName(selectedVesselName);
                    vessel.Captain = captain;
                    captain.AddVessel(vessel);
                    return String.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
                }
            }
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            if (this.vessels.FindByName(attackingVesselName) == null)
            {
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            else if (this.vessels.FindByName(defendingVesselName) == null)
            {
                return String.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }
            else if (this.vessels.FindByName(attackingVesselName).ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            else if (this.vessels.FindByName(defendingVesselName).ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }
            else
            {
                this.vessels.FindByName(attackingVesselName).Attack(this.vessels.FindByName(defendingVesselName));
                this.vessels.FindByName(attackingVesselName).Captain.IncreaseCombatExperience();
                this.vessels.FindByName(defendingVesselName).Captain.IncreaseCombatExperience();
                return String.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, this.vessels.FindByName(defendingVesselName).ArmorThickness);
            }
        }

        public string CaptainReport(string captainFullName)
        {
            return this.captains.FirstOrDefault(x => x.FullName == captainFullName).Report();
        }

        public string HireCaptain(string fullName)
        {
            if (this.captains.Select(x => x.FullName).Contains(fullName))
            {
                return String.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }
            else
            {
                this.captains.Add(new Captain(fullName));
                return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
            }
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            var vessel = this.vessels.FindByName(name);
            if (vessel == null)
            {
                if (vesselType == "Battleship")
                {
                    this.vessels.Add(new Battleship(name, mainWeaponCaliber, speed));
                    return String.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
                }
                else if (vesselType == "Submarine")
                {
                    this.vessels.Add(new Submarine(name, mainWeaponCaliber, speed));
                    return String.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);

                }
                else
                {
                    return OutputMessages.InvalidVesselType;
                }
            }
            else
            {
                return String.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }
        }

        public string ServiceVessel(string vesselName)
        {
            var vessel = this.vessels.FindByName(vesselName);
            if (vessel != null)
            {
                vessel.RepairVessel();
                return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
            }
            else
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }
        }


        public string ToggleSpecialMode(string vesselName)
        {
            var vessel = this.vessels.FindByName(vesselName);
            if (vessel != null)
            {
                if (vessel.GetType().Name == "Battleship")
                {
                    var battleship = vessel as Battleship;
                    battleship.ToggleSonarMode();
                    vessel = battleship;
                    return String.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
                }
                else
                {
                    var battleship = vessel as Submarine;
                    battleship.ToggleSubmergeMode();
                    vessel = battleship;
                    return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);

                }

            }
            else
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }
        }

        public string VesselReport(string vesselName)
        {
            return this.vessels.Models.FirstOrDefault(x => x.Name == vesselName).ToString();
        }
    }
}
