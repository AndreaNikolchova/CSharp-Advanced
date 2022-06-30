using System;
using System.Linq;

namespace Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int[,] matrix = new int[num, num];
            for (int i = 0; i < num; i++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for (int k = 0; k < num; k++)
                {
                    matrix[i, k] = row[k];
                }
            }
            char symbol = char.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                for (int k = 0; k < num; k++)
                {
                    if (matrix[i, k]== symbol)
                    {
                        Console.WriteLine($"({i}, {k})");
                         return; 
                    }
                    
                }
            }
            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
