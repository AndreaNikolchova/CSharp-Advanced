using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Models.Contracts;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            this.privates = new List<Private>();
        }

        private readonly List<Private> privates = new List<Private>();
        public IReadOnlyCollection<Private> Privates { get { return this.privates.AsReadOnly(); } }
        public void Add(Private @private)
        {
            this.privates.Add(@private);
        }
        public override string ToString()
        {
            if(this.Privates.Count == 0)
                return base.ToString() + $"{Environment.NewLine}Privates:";
            else
                return base.ToString() + $"{Environment.NewLine}Privates:" + Environment.NewLine + "  " + String.Join(Environment.NewLine + "  ",this.privates);
        }
    }
}
