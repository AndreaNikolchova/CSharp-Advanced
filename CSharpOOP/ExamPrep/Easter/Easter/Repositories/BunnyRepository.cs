
namespace Easter.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Easter.Models.Bunnies.Contracts;

    public class BunnyRepository : IRepository<IBunny>
    {
        public BunnyRepository()
        {
            this.models = new List<IBunny>();
        }
        private List<IBunny> models;
        public IReadOnlyCollection<IBunny> Models
        {
            get { return this.models.AsReadOnly(); }
        }

        public void Add(IBunny model)
        {
           this.models.Add(model);
        }

        public IBunny FindByName(string name)
        {
            return this.models.FirstOrDefault(x=>x.Name==name);
        }

        public bool Remove(IBunny model)
        {
            return this.models.Remove(model);
        }
    }
}
