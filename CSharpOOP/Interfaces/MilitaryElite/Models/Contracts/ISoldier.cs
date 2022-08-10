using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models.Contracts
{
    public interface ISoldier
    {
        string Id { get; }
        string FistName { get; }
        string LastName { get; }

    }
}
