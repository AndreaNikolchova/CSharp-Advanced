using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        //        •	Model: a string property.
        //•	Power: an int property.
        //•	Displacement: an int property, it is optional.
        //•	Efficiency: a string property, it is optional.
        private string model;
        private int power;
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        private int displacement;

        public int Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }
        private string efficiency;

        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }
        public Engine(string model, int power,int displasment,string efficiancy)
        {
            this.model = model;
            this.power = power;
            this.displacement = displasment;
            this.efficiency = efficiancy;
        }


    }
}
