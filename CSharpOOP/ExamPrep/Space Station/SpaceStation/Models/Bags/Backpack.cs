
namespace SpaceStation.Models.Bags
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    public class Backpack : IBag
    {
        public Backpack()
        {
            this.items = new List<string>();
        }
        private List<string> items;
        public ICollection<string> Items
        {
            get { return this.items; }
        }
    }
}
