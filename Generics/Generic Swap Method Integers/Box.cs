using System;
using System.Collections.Generic;
using System.Text;

namespace Generic_Swap_Method_Integers
{
    internal class Box<T>
    {
        public List<T> List { get; set; }

        public Box()
        {
            List = new List<T>();
        }
        public void Swap(int indexOne, int indexTwo)
        {
            var valueOfIndexOne = List[indexOne];
            var valueOfIndexTwo = List[indexTwo];
            List[indexOne] = valueOfIndexTwo;
            List[indexTwo] = valueOfIndexOne;

        }
        public void Print()
        {
            foreach (var item in List)
            {
                Console.WriteLine($"{typeof(T)}: {item}");
            }
        }
    }
}
