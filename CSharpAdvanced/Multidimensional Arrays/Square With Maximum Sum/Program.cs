using System;
using System.Collections.Generic;
using System.Linq;

namespace Square_With_Maximum_Sum
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
                int[] row1 = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int k = 0; k < cols; k++)
                {
                    matrix[i, k] = row1[k];
                }
            }
            int maxValue = int.MinValue;
            int row = 0;
            int col = 0;    
            for (int i = 0; i < rows-1; i++)
            {
                for (int k = 0; k < cols-1; k++)
                {
                    int sumOfSquare = matrix[i, k] + matrix[i + 1, k] + matrix[i, k + 1] + matrix[i + 1, k + 1];
                    if (sumOfSquare>maxValue)
                    {
                        maxValue = sumOfSquare;
                        row = i;
                        col = k;
                    }
                }
            }
            Console.WriteLine($"{matrix[row, col]} {matrix[row, col+1]}");
            Console.WriteLine($"{matrix[row+1, col]} {matrix[row+1, col + 1]}");
            Console.WriteLine(maxValue);
                
        }
    }
}
