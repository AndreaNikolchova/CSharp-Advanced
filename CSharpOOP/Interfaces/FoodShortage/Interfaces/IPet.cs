using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Interfaces
{
    public interface IPet : IBirthable
    {
        string Name { get; }
    }
}
