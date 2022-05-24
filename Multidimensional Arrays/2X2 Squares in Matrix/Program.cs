using System;
using System.Linq;

namespace _2X2_Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string[,] matrix = new string[input[0],input[1]];
            int countOfSquares = 0;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                string[] row = Console.ReadLine().Split(" ");
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = row[cols];
                }
            }
            for (int rows = 0; rows < matrix.GetLength(0)-1; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1)-1; cols++)
                {
                    if (matrix[rows,cols]==matrix[rows,cols+1]&& matrix[rows, cols] == matrix[rows+1, cols]&& matrix[rows, cols] == matrix[rows+1, cols + 1])
                    {
                        countOfSquares++;
                    }
                }
            }
            Console.WriteLine(countOfSquares);

        }
    }
}
