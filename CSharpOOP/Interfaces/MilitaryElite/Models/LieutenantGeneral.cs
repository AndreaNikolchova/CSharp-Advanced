namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    public class LieutenantGeneral : Private
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            this.privates = new List<Private>();
        }

        private readonly List<Private> privates;
        public IReadOnlyCollection<Private> Privates { get { return privates; } }
    }
}
