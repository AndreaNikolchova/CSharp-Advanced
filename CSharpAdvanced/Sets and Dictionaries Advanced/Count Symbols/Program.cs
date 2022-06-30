using System;
using System.Collections.Generic;

namespace Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char,int> dictionary = new SortedDictionary<char, int>();
            char[] phrase = Console.ReadLine().ToCharArray();
            foreach (char c in phrase)
            {
                if (dictionary.ContainsKey(c))
                    dictionary[c]++;
                else
                    dictionary.Add(c, 1);
            }
            foreach (var symbol in dictionary)
                    Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
        }
    }
}
