
namespace PlanetWars.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.MilitaryUnits.Contracts;
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        public UnitRepository()
        {
            this.models = new List<IMilitaryUnit>();
        }
        private List<IMilitaryUnit> models;
        public IReadOnlyCollection<IMilitaryUnit> Models
        {
            get { return this.models.AsReadOnly(); }
        }

        public void AddItem(IMilitaryUnit model)
        {
            this.models.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            return this.models.FirstOrDefault(x=>x.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            return this.models.Remove(this.models.FirstOrDefault(x => x.GetType().Name == name));
        }
    }
}
