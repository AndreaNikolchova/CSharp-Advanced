
namespace PlanetWars.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Weapons.Contracts;
    public class WeaponRepository : IRepository<IWeapon>
    {
        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }
        private List<IWeapon> models;
        public IReadOnlyCollection<IWeapon> Models
        {
            get { return this.models.AsReadOnly(); }
        }

        public void AddItem(IWeapon model)
        {
           this.models.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            return this.models.Remove(this.models.FirstOrDefault(x => x.GetType().Name == name));
        }
    }
}
