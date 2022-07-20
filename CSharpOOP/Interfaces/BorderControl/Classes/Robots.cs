using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robots : IRobot
    {
        public string Id { get; private set; }

        public string Name { get; private set; }
        public Robots(string name , string id)
        {
            this.Name = name;
            this.Id = id;
        }
    }
}
