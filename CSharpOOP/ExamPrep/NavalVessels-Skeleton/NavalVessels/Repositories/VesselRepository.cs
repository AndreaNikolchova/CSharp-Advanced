
namespace NavalVessels.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using NavalVessels.Models.Contracts;

    public class VesselRepository : IRepository<IVessel>
    {
        public VesselRepository()
        {
            this.models = new List<IVessel>();
        }
        private List<IVessel> models;
        public IReadOnlyCollection<IVessel> Models
        {
            get { return this.models.AsReadOnly(); }
        }
        public void Add(IVessel model)
        {
           this.models.Add(model);
        }

        public IVessel FindByName(string name)
        {
           return this.models.FirstOrDefault(x=>x.Name == name);
        }

        public bool Remove(IVessel model)
        {
           return models.Remove(model);
        }
    }
}
