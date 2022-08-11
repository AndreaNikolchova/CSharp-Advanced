
namespace Gym.Models.Athletes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Utilities.Messages;
    public class Boxer : Athlete
    {
        private const int stamina = 60;

        public Boxer(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, stamina)
        {
        }

        public override void Exercise()
        {
            base.Stamina += 15;
            if (base.Stamina>100)
            {
                base.Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
        }
    }
}
