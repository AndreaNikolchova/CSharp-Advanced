using System;
using System.Collections.Generic;
using System.Text;

namespace Box
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
