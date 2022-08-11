
namespace Gym.Models.Athletes.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Utilities.Messages;
    public class Weightlifter : Athlete
    {
        private const int stamina = 50;
        public Weightlifter(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, stamina)
        {
        }

        public override void Exercise()
        {
            base.Stamina += 10;
            if (base.Stamina > 100)
            {
                base.Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
        }
    }
}
