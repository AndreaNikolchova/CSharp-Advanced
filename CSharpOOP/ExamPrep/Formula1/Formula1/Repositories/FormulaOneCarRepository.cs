
namespace Formula1.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Formula1.Models.Contracts;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        public FormulaOneCarRepository()
        {
            this.models = new List<IFormulaOneCar>();
        }
        private List<IFormulaOneCar> models;
        public IReadOnlyCollection<IFormulaOneCar> Models { get { return this.models.AsReadOnly(); } }

        public void Add(IFormulaOneCar model)
        {
            this.models.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
           return this.models.FirstOrDefault(x =>x.Model == name);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return this.models.Remove(model);
        }
    }
}
