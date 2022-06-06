using System;

namespace Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            Predicate<string> filter = x => char.IsUpper(x[0]) && x.Length > 0;
            foreach (var word in text)
            {
                if (filter(word))
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
