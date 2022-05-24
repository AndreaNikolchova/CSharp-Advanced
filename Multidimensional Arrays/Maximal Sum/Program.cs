using System;
using System.Linq;

namespace Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[,] matrix = new int[input[0], input[1]];
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] row1 = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = row1[cols];
                }
            }
            int maxSum = 0;
            int row = 0;
            int col = 0;
            for (int rows = 0; rows < matrix.GetLength(0)-2; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1)-2; cols++)
                {
                    int sumOfSquare = matrix[rows, cols]+matrix[rows,cols+1]+matrix[rows, cols+2]+matrix[rows+1,cols]+matrix[rows+1,cols+1]+matrix[rows+1,cols+2]+matrix[rows+2,cols]+matrix[rows+2,cols+1]+matrix[rows+2,cols+2];
                    if (sumOfSquare>maxSum)
                    {
                        maxSum = sumOfSquare;
                        row = rows;
                        col = cols;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[row, col]} {matrix[row,col+1]} {matrix[row, col+2]}");
            Console.WriteLine($"{matrix[row+1, col]} {matrix[row+1, col + 1]} {matrix[row+1, col + 2]}");
            Console.WriteLine($"{matrix[row+2, col]} {matrix[row+2, col + 1]} {matrix[row+2, col + 2]}");

        }
    }
}
