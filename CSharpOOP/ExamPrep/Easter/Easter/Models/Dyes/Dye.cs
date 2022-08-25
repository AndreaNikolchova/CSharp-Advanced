
namespace Easter.Models.Dyes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    public class Dye : IDye
    {
        public Dye(int power)
        {
            this.Power = power;
        }
        private int power;
        public int Power
        {
            get { return this.power; }
            private set 
            {
                if(value < 0)
                    this.power = 0;
                else
                this.power = value; 
            }
        }

        public bool IsFinished()
        {
            if(this.Power == 0)
            {
                return true;
            }
            else
                return false;
        }

        public void Use()
        {
            if (this.Power - 10 < 0)
                this.Power = 0;
            else
                this.Power -= 10;
        }
    }
}
