
namespace Heroes.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Contracts;
    public class WeaponRepository : IRepository<IWeapon>
    {
        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }
        private List<IWeapon> models;
        public IReadOnlyCollection<IWeapon> Models
        {
            get { return models.AsReadOnly(); }
        }

        public void Add(IWeapon model)
        {
           this.models.Add(model);
        }

        public IWeapon FindByName(string name)
        {
           return this.models.FirstOrDefault(x=>x.Name == name);
        }

        public bool Remove(IWeapon model)
        {
            return this.models.Remove(model);
        }
    }
}
