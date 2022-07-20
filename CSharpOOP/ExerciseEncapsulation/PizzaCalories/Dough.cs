using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double white = 1.5;
        private const double wholegrain = 1.0;
        private const double crispy = 0.9;
        private const double chewy = 1.1;
        private const double homemade = 1.0;
        private double flour;
        private double bakingTechnique;
        private int weight;

        public Dough(string flour, string bakingTechnique,int weight)
        {
            switch(flour.ToLower())
            {
                case "white":
                    this.Flour = white;
                    break;
                case "wholegrain":
                    this.Flour = wholegrain;
                    break;
                    default:
                    this.Flour=0;
                    break;

            }
            switch (bakingTechnique.ToLower())
            {
                case "crispy":
                    this.BakingTechnique = crispy;
                    break;
                case "chewy":
                    this.BakingTechnique= chewy;
                    break;
                case "homemade":
                    this.BakingTechnique = homemade;
                    break;
                default:
                    this.BakingTechnique = 0;
                    break;
            }
            this.Weight = weight;

        }
        public double Flour
        {
            get
            {
                return this.flour;
            }
           private set
            {
                if (value==0)
                    throw new Exception("Invalid type of dough.");
                else 
                    this.flour = value;

            }

        }
        public double BakingTechnique
        {
            get 
            { 
                return this.bakingTechnique; 
            }
            private set
            {
                if (value == 0)
                    throw new Exception("Invalid type of dough.");
                else
                    this.bakingTechnique = value;
            }
        }

        public int Weight 
        { 
            get
            {
                return this.weight;
            }
             private set 
            {
                if (value<0||value>200)
                    throw new Exception("Dough weight should be in the range [1..200].");
                else
                this.weight = value;
            }
        }
        public double Grams()
        {
            return (this.Weight*2)*this.Flour*this.bakingTechnique;
        }
    }
}
