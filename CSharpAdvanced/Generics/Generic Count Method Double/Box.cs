using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generic_Count_Method_Double
{
    public class Box<T>: IComparable<T> where T : IComparable<T>
    {
        public List<T> Elements { get; }

        public T Element { get; }
        public Box(List<T> elemntsList)
        {
            Elements = elemntsList;
        }
        public int CompareTo(T other) => Element.CompareTo(other);
        public int CountOFGreaterElements<T>(List<T> list, T readLine) where T : IComparable
            => list.Count(word => word.CompareTo(readLine) > 0);

    }
}
