using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public abstract class BaseHero
    {
        public BaseHero(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
        public virtual int Power { get; set; }
        public abstract string CastAbility();
    }
}
