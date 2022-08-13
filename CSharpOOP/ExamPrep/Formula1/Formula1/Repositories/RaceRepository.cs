
namespace Formula1.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models.Contracts;
    using Contracts;
    using System.Linq;

    public class RaceRepository : IRepository<IRace>
    {
        public RaceRepository()
        {
            this.models = new List<IRace>();
        }
        private List<IRace> models;
        public IReadOnlyCollection<IRace> Models { get { return this.models; } }

        public void Add(IRace model)
        {
           this.models.Add(model);
        }

        public IRace FindByName(string name)
        {
            return this.models.FirstOrDefault(x=>x.RaceName == name);
        }

        public bool Remove(IRace model)
        {
            return this.models.Remove(model);
        }
    }
}
