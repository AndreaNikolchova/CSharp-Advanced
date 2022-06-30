using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class Threeuple<TFirstValue, TSecondValue, TThirdValue>
    {
        public TFirstValue FirstValue { get; set; }
        public TSecondValue SecondValue { get; set; }
        public TThirdValue ThirdValue { get; set; }
        public Threeuple(TFirstValue firstValue, TSecondValue secondValue, TThirdValue thirdValue)
        {
            this.FirstValue = firstValue;
            this.SecondValue = secondValue;
            this.ThirdValue = thirdValue;   
        }
        public override string ToString()
        {
            return $"{FirstValue} -> {SecondValue} -> {ThirdValue}";
        }
    }
}
