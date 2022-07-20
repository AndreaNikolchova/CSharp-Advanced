using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private int height;
        private int width;
        public int Height
        {
            get { return this.height; }
            private set { this.height = value; }
        }
        public int Width
        {
            get { return this.width; }
            private set { this.width = value; }
        }
        public Rectangle(int height, int wight)
        {
            this.Height = height;
            this.Width = wight;
        }
        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
           return 2 * this.Height + 2 * this.Width;
        }
        public override string Draw()
        {
            return base.Draw();
        }
    }
}
