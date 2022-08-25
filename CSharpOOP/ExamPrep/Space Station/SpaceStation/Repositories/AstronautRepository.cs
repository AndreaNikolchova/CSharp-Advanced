
namespace SpaceStation.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Astronauts.Contracts;
    public class AstronautRepository : IRepository<IAstronaut>
    {
        public AstronautRepository()
        {
            this.models = new List<IAstronaut>();
        }
        private readonly List<IAstronaut> models;
        public IReadOnlyCollection<IAstronaut> Models
        {
            get { return models; }
        }

        public void Add(IAstronaut model)
        {
            this.models.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IAstronaut model)
        {
            return this.models.Remove(model);
        }
    }
}
