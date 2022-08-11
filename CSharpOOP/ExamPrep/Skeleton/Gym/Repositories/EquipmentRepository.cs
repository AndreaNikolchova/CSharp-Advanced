namespace Gym.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Equipment.Contracts;
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> models = new List<IEquipment>();
        public IReadOnlyCollection<IEquipment> Models { get { return this.models.AsReadOnly(); } }

        public void Add(IEquipment model)
        {
           this.models.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            return this.models.FirstOrDefault(x=>x.GetType().Name == type);
        }

        public bool Remove(IEquipment model)
        {
           return this.models.Remove(model);
        }
    }
}
