using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple <TFirstValue,TSecondValue>
    {
        public TFirstValue FirstValue { get; set;}
        public TSecondValue SecondValue { get; set;}
        public Tuple(TFirstValue firstValue, TSecondValue secondValue)
        {
            this.FirstValue = firstValue;
            this.SecondValue = secondValue;
        }
        public override string ToString()
        {
            return $"{FirstValue} -> {SecondValue}";
        }
    }
}
