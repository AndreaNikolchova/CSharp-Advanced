
namespace Formula1.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Contracts;
    public class PilotRepository : IRepository<IPilot>
    {
        public PilotRepository()
        {
            this.models = new List<IPilot>();
        }
        private List<IPilot> models;
        public IReadOnlyCollection<IPilot> Models { get { return this.models.AsReadOnly(); } }

        public void Add(IPilot model)
        {
            this.models.Add(model);
        }

        public IPilot FindByName(string name)
        {
           return this.models.FirstOrDefault(x=>x.FullName == name);
        }

        public bool Remove(IPilot model)
        {
            return this.models.Remove(model);
        }
    }
}
