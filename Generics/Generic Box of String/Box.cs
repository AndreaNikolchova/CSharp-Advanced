using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Box_of_String
{
    public class Box<T>
    {
        private T getT;

        public T GetT
        {
            get { return getT; }
            set { getT = value; }
        }
        public Box(T type)
        {
            this.getT = type;
        }
        public override string ToString()
        {
            return $"{typeof(T)}: {getT}";
        }

    }
}
