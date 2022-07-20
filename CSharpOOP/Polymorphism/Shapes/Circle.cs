using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle:Shape
    {
        private int radius;
        public int Radius
        {
            get { return this.radius; }
            private set { this.radius = value; }
        }
        public Circle(int radius)
        {
            this.Radius = radius;
        }
        public override double CalculatePerimeter()
        {
            return 0;
        }

        public override double CalculateArea()
        {
            return 0;
        }
        public override string Draw()
        {
            return base.Draw();
        }
    }
}
