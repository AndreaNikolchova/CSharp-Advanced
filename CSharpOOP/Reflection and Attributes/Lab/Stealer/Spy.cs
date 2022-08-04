namespace Stealer
{
    using System;
    using System.Text;
    using System.Reflection;
    using System.Linq;
    public class Spy
    {
        public string CollectGettersAndSetters(string className)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Type hackerClass = Type.GetType(className);
            var Metods = hackerClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic| BindingFlags.Public|BindingFlags.Static);
            foreach(var metod in Metods)
            {
                if (metod.Name.StartsWith("get"))
                {
                    stringBuilder.AppendLine($"{metod.Name} will return {metod.ReturnType}");
                }
                
            }
            foreach (var metod in Metods)
            {
                if (metod.Name.StartsWith("set"))
                {
                    stringBuilder.AppendLine($"{metod.Name} will set field of {metod.GetParameters().First().ParameterType}");
                }

            }
            return stringBuilder.ToString().Trim();
        }
        public string RevealPrivateMethods(string className)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Type hackerClass = Type.GetType(className);
            stringBuilder.AppendLine($"All Private Methods of Class: {className}");
            stringBuilder.AppendLine($"Base Class: {hackerClass.BaseType.Name}");
            var notPublicMetods = hackerClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach(var metods in notPublicMetods)
            {
                stringBuilder.AppendLine(metods.Name);
            }
            return stringBuilder.ToString().Trim();

        }
        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Type hackerClass = Type.GetType(className);
            var fields = hackerClass.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            var publicMetods = hackerClass.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            var notPublicMetods = hackerClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (FieldInfo field in fields)
            {
                stringBuilder.AppendLine($"{field.Name} must be private!");
            }
            foreach (MethodInfo method in notPublicMetods)
            {
                if (method.Name.StartsWith("get"))
                {
                    stringBuilder.AppendLine($"{method.Name} must be public!");
                }
            }
            foreach (MethodInfo method in publicMetods)
            {
                if (method.Name.StartsWith("set"))
                {
                    stringBuilder.AppendLine($"{method.Name} must be private!");
                }
            }
            return stringBuilder.ToString().Trim();
        }
        public string StealFieldInfo(string nameOfClass, params string[] namesOfFields)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Type hackerClass =  Type.GetType(nameOfClass);
            var instance = Activator.CreateInstance(hackerClass);
            var fields =  hackerClass.GetFields(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Static|BindingFlags.Instance);
           stringBuilder.AppendLine($"Class under investigation: {nameOfClass}");
            foreach (var field in fields)
            {
                if (namesOfFields.Contains(field.Name))
                {
                   stringBuilder.AppendLine($"{field.Name} = {field.GetValue(instance)}");
                }
            }
            return stringBuilder.ToString().Trim();
        }
    }
}
