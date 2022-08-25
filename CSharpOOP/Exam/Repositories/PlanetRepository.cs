
namespace PlanetWars.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Planets.Contracts;
    public class PlanetRepository : IRepository<IPlanet>
    {

        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }
        private List<IPlanet> models;
        public IReadOnlyCollection<IPlanet> Models
        { get { return this.models.AsReadOnly(); } }

        public void AddItem(IPlanet model)
        {
            this.models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool RemoveItem(string name)
        {
            return this.models.Remove(this.models.FirstOrDefault(x => x.Name == name));
        }
    }
}
