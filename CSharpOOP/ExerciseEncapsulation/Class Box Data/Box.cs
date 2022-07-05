using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Box_Data
{
    public class Box
    {
        private double length;
        public double Length
        {
            get 
            { 
                return this.length; 
            }
            private set 
            {
                if (value <= 0)
                    throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
                else
                    this.length = value;
                 
            }
        }

        private double width;
        public double Width
        {
            get 
            { 
                return this.width;
            }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
                else
                    this.width = value;
            }

        }
        private double height;

        public double Height
        {
            get 
            { 
                return this.height; 
            }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");
                else
                    this.height = value;
            }
        }
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        public double SurfaceArea()
        {
            return 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }
        public double LateralSurfaceArea()
        {
            return 2 * this.Height*this.Length +2*this.Height*this.Width;
        }
        public double Volume()
        {
            return this.Length * this.Width * this.Height;
        }
        public override string ToString()
        {
            return $"Surface Area - {this.SurfaceArea():f2}{Environment.NewLine}Lateral Surface Area - {this.LateralSurfaceArea():f2}{Environment.NewLine}Volume - {this.Volume():f2}";
        }
    }
}
