
namespace Gym.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Gym.Models.Athletes;
    using Gym.Models.Athletes.Contracts;
    using Gym.Models.Equipment;
    using Gym.Models.Equipment.Contracts;
    using Gym.Models.Gyms;
    using Models.Gyms.Contracts;
    using Repositories;
    using Utilities.Messages;
    public class Controller : IController
    {
        private EquipmentRepository equipment = new EquipmentRepository();
        private List<IGym> gyms = new List<IGym>();
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);
            IAthlete athlete = null;
            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
                if (gym.GetType().Name != "BoxingGym")
                {
                    return OutputMessages.InappropriateGym;
                }
                gym.AddAthlete(athlete);
                return String.Format(OutputMessages.EntityAddedToGym,athleteType , gymName);
            }
            else if(athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                if (gym.GetType().Name != "WeightliftingGym")
                {
                    return OutputMessages.InappropriateGym;
                }
                gym.AddAthlete(athlete);
                return String.Format(OutputMessages.EntityAddedToGym,athleteType , gymName);
            }
            else 
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment currentEquipment = null;
            if (equipmentType == "BoxingGloves")
            {
                currentEquipment = new BoxingGloves();
                equipment.Add(currentEquipment);
                return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
            }
            else if (equipmentType == "Kettlebell")
            {
                currentEquipment = new Kettlebell();
                equipment.Add(currentEquipment);
                return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
            }
            else
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym = null;
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
                gyms.Add(gym);
                return string.Format(OutputMessages.SuccessfullyAdded,gymType);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
                gyms.Add(gym);
                return string.Format(OutputMessages.SuccessfullyAdded,gymType);
            }
            else
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);
            return string.Format(OutputMessages.EquipmentTotalWeight, gymName,gym.EquipmentWeight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);
            IEquipment currentEquipment = equipment.Models.FirstOrDefault(x=> x.GetType().Name == equipmentType);
            if (currentEquipment != null)
            {
                gym.AddEquipment(currentEquipment);
                equipment.Remove(currentEquipment);
                return String.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);

            }
            else
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
        }

        public string Report()
        {
            return String.Join(Environment.NewLine, gyms.Select(x=>x.GymInfo()));
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);
            gym.Exercise();
            return String.Format(OutputMessages.AthleteExercise,gym.Athletes.Count);
        }
    }
}
