
namespace SpaceStation.Repositories
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
        private readonly List<IPlanet> models;
        public IReadOnlyCollection<IPlanet> Models
        {
            get { return this.models.AsReadOnly(); }
        }

        public void Add(IPlanet model)
        {
            this.models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IPlanet model)
        {
            return this.models.Remove(model);
        }
    }
}
