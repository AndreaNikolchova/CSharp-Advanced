﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models.Contracts
{
    public  interface IComando
    {
        IReadOnlyCollection<Mission> Missions { get; }
    }
}
