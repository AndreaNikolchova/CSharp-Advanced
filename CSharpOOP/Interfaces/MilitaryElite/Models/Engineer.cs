using System.Collections.Generic;

namespace MilitaryElite.Models
{
    public class Engineer : Private
    {
        public Engineer(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            repairs = new List<Repair>();
        }
        private List<Repair> repairs;
        public IReadOnlyCollection<Repair> Repairs { get { return this.repairs; } }

    }
}
