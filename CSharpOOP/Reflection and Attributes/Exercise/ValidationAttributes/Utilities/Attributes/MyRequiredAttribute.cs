using System;

namespace ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if (obj is string str)
            {
               return !string.IsNullOrWhiteSpace(str);
            }
            return obj != null;
        }
    }
}
