namespace AuthorProblem
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class Tracker
    {
        public void PrintMethodsByAuthor()
        { 
            Type start = typeof(StartUp);
            MethodInfo[] methods = start.GetMethods(BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Static);
            foreach (MethodInfo method in methods)
            {
                
                    var atributes = method.GetCustomAttributes(typeof(AuthorAttribute),true);
                    foreach (AuthorAttribute autor in atributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {autor.Name}");
                    }

                
            }
        }
    }
}