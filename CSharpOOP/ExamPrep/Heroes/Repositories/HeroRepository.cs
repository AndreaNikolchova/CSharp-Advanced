
namespace Heroes.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Contracts;
    public class HeroRepository : IRepository<IHero>
    {
        public HeroRepository()
        {
            this.models = new List<IHero>();
        }
        private List<IHero> models = new List<IHero>();
        public IReadOnlyCollection<IHero> Models
        {
            get { return this.models.AsReadOnly(); }
        }

        public void Add(IHero model)
        {
            this.models.Add(model);
        }

        public IHero FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IHero model)
        {
           return this.models.Remove(model);
        }
    }
}
