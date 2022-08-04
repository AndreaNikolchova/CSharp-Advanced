namespace ValidationAttributes
{
    using System;
    using System.Linq;
    using System.Reflection;
    public static class Validator 
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type
                .GetProperties()
                .Where(pi => pi.CustomAttributes.Any(a => a.AttributeType.BaseType == typeof(MyValidationAttribute)))
               .ToArray();

            foreach (PropertyInfo property in properties)
            {
                var propValue = property.GetValue(obj);

               foreach(CustomAttributeData customAttributeData in property.CustomAttributes)
               {
                  Type customAttrType = customAttributeData.AttributeType;
                  object attributeInstance = property
                     .GetCustomAttribute(customAttrType);
                    
                    MethodInfo validationMethod = customAttrType
                        .GetMethods()
                        .First(m => m.Name == "IsValid");

                    bool result = (bool)validationMethod
                        .Invoke(attributeInstance, new object[] { propValue });

                    if (!result)
                    {
                        return false;
                    }
               }
            }
            
            return true;

        }
    }
}
