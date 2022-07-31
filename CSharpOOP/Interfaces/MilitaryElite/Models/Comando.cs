using System.Collections.Generic;

namespace MilitaryElite.Models
{
    public class Comando:Private
    {
        public Comando(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            missions = new List<Mission>();
        }
        private List<Mission> missions;
        public IReadOnlyCollection<Mission> Repairs { get { return this.missions; } }
    }
}
