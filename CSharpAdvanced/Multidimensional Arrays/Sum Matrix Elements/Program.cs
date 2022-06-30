using System;
using System.Linq;

namespace Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            (int rows, int cols) = (input[0], input[1]);
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                int[] row = Console.ReadLine().Split("< ").Select(int.Parse).ToArray();
                for (int k = 0; k < cols; k++)
                {
                    matrix[i,k] = row[k];
                }
            }
            int sum = 0;
            for (int i = 0; i < rows; i++)
            {
               
                for (int k = 0; k < cols; k++)
                {
                    sum += matrix[i, k];
                }
            }
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}
