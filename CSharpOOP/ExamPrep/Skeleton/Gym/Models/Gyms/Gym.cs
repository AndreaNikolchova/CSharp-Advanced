namespace Gym.Models.Gyms
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Utilities.Messages;
    using Models.Athletes.Contracts;
    using Models.Equipment.Contracts;
    using System.Linq;

    public abstract class Gym : IGym
    {
        protected Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            equipment = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }
        private string name;
        public string Name
        {
            get { return this.name; }
            private set 
            {
                if(string.IsNullOrEmpty(value))
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight { get { return this.equipment.Sum(x => x.Weight); } }

        private List<IEquipment> equipment;
        private List<IAthlete> athletes;
        public ICollection<IEquipment> Equipment
        {
            get { return this.equipment.AsReadOnly(); }
        }

        public ICollection<IAthlete> Athletes
        {
            get { return this.athletes.AsReadOnly(); }
        }

       

        public void AddAthlete(IAthlete athlete)
        {
            if (this.athletes.Count == this.Capacity)
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            else
                this.athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
           this.equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var ath in athletes)
                ath.Exercise();
        }

        public string GymInfo()
        {
            if (athletes.Count == 0)
            {
                return $"{this.Name} is a {this.GetType().Name}:" +
                    $"{Environment.NewLine}Athletes: No athletes" +
                    $"{Environment.NewLine}Equipment total count: {this.equipment.Count}" +
                    $"{Environment.NewLine}Equipment total weight: {this.EquipmentWeight:f2} grams";

            }
            else
            {
                return $"{this.Name} is a {this.GetType().Name}:" +
                    $"{Environment.NewLine}Athletes: {string.Join(", ",this.athletes.Select(x=>x.FullName))}" +
                    $"{Environment.NewLine}Equipment total count: {this.equipment.Count}" +
                    $"{Environment.NewLine}Equipment total weight: {this.EquipmentWeight:f2} grams";
            }
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
           return this.athletes.Remove(athlete);
        }
    }
}
