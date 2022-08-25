namespace CarRacing.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Utilities.Messages;
    using Contracts;

    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> models;
        public IReadOnlyCollection<IRacer> Models
        {
            get { return this.models.AsReadOnly(); }
        }

        public void Add(IRacer model)
        {
            if (model == null)
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            this.models.Add(model);
        }

        public IRacer FindBy(string property)
        {
            return this.models.FirstOrDefault(x => x.Username == property);
        }

        public bool Remove(IRacer model)
        {
            return this.models.Remove(model);
        }
    }
}
