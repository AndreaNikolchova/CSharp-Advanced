using System;
using System.Collections.Generic;
using System.Linq;

namespace Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int rows = 0; rows < n; rows++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                for (int cols = 0; cols < n; cols++)
                {
                    matrix[rows, cols] = line[cols];
                }
            }
            InMatrix(matrix);

        }
        public static int CountOfRemoved;
        static void InMatrix(char[,] matrix)
        {
            Dictionary<(int,int),int>  dictionary = new Dictionary<(int,int),int>();
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (matrix[rows, cols] == 'K')
                    {
                        dictionary.Add((rows, cols),KMovement(rows,cols,matrix));
                    }

                }

            }
            (int row, int col) = (0,0);
            if (dictionary.Count>0)
            {
                int maxValue = dictionary.Values.Max();
                if (maxValue == 0)
                {
                    Console.WriteLine(CountOfRemoved);
                    return;
                }
                else
                {
                    foreach (var value in dictionary)
                    {
                        if (maxValue == value.Value)
                            (row, col) = value.Key;
                    }
                    dictionary.Remove((row, col));
                    CountOfRemoved++;
                    matrix[row, col] = '0';
                    InMatrix(matrix);

                }
            }
            else
            {
                Console.WriteLine(CountOfRemoved);
                return;
            }
           

        }
        static int KMovement(int rows, int cols, char[,] matrix)
        {
            int count = 0;
            if (matrix.GetLength(0) > rows + 2 && rows + 2 >= 0 && matrix.GetLength(1) > cols - 1 && cols - 1 >= 0)
                if (matrix[rows + 2, cols - 1] == 'K')
                     count++;

            if (matrix.GetLength(0) > rows + 2 && rows + 2 >= 0 && matrix.GetLength(1) > cols + 1 && cols + 1 >= 0)
                if(matrix[rows + 2, cols + 1] == 'K')
                    count++;

            if (matrix.GetLength(0) > rows - 2 && rows - 2 >= 0 && matrix.GetLength(1) > cols + 1 && cols + 1 >= 0)
                if(matrix[rows - 2, cols + 1] == 'K')
                    count++;

            if (matrix.GetLength(0) > rows - 2 && rows - 2 >= 0 && matrix.GetLength(1) > cols - 1 && cols - 1 >= 0)
                if(matrix[rows - 2, cols - 1] == 'K')
                    count++;

            if (matrix.GetLength(0) > rows - 1 && rows - 1 >= 0 && matrix.GetLength(1) > cols + 2 && cols + 2 >= 0)
                if(matrix[rows - 1, cols + 2] == 'K')
                     count++;

            if (matrix.GetLength(0) > rows + 1 && rows + 1 >= 0 && matrix.GetLength(1) > cols + 2 && cols + 2 >= 0)
                if(matrix[rows + 1, cols + 2] == 'K')
                    count++;

            if ( matrix.GetLength(0) > rows + 1 && rows + 1 >= 0 && matrix.GetLength(1) > cols - 2 && cols - 2 >= 0)
                if(matrix[rows + 1, cols - 2] == 'K')
                     count++;

            if (matrix.GetLength(0) > rows - 1 && rows - 1 >= 0 && matrix.GetLength(1) > cols - 2 && cols - 2 >= 0)
                if(matrix[rows - 1, cols - 2] == 'K')
                    count++;

            return count;

        }
    }
}
