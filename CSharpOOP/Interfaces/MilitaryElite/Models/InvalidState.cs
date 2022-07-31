using System;

namespace MilitaryElite.Models
{

    internal class InvalidState : Exception
    {
        public InvalidState(string message) : base(message)
        {
        }
    }
}