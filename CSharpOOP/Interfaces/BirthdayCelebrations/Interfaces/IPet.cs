using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations.Interfaces
{
    public interface IPet : IBirthable
    {
        string Name { get; }
    }
}
