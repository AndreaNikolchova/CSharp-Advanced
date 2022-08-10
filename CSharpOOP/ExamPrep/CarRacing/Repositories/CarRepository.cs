namespace CarRacing.Repositories
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Repositories.Contracts;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class CarRepository: IRepository<ICar>
    {
        private List<ICar> models;
        public IReadOnlyCollection<ICar> Models
        {
            get { return this.models.AsReadOnly(); }
        }

        public void Add(ICar model)
        {
            if( model == null)
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            this.models.Add(model);
        }

        public ICar FindBy(string property)
        {
            return this.models.FirstOrDefault(x => x.VIN == property);
        }

        public bool Remove(ICar model)
        {
            return this.models.Remove(model);
        }
    }
}
