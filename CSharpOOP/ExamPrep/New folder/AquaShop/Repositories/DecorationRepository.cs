
namespace AquaShop.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AquaShop.Models.Decorations.Contracts;
    using Contracts;
    public class DecorationRepository : IRepository<IDecoration>
    {
        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }
        private readonly List<IDecoration> models;
        public IReadOnlyCollection<IDecoration> Models
        { get { return this.models.AsReadOnly(); } }

        public void Add(IDecoration model)
        {
           this.models.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            return this.models.FirstOrDefault(x=>x.GetType().Name == type);
        }

        public bool Remove(IDecoration model)
        {
           return this.models.Remove(model);
        }
    }
}
