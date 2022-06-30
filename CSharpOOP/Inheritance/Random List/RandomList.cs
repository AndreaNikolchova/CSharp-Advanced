using System;
using System.Collections.Generic;
using System.Text;

namespace Random_List
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            var randomIndex = new Random();
            int index = randomIndex.Next(0, base.Count);
            base.RemoveAt(index);
            return base[index];
        }
    }
}
