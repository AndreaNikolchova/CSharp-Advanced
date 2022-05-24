using System;
using System.Linq;

namespace Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            char[,] matrix = new char[input[0], input[1]];
            string word = Console.ReadLine();
            int i = 0;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {

                if (rows % 2 == 0)
                {
                    for (int cols = 0; cols < matrix.GetLength(1); cols++)
                    {
                       
                        if (i > word.Length-1)
                        {
                            i = 0;
                        }
                        matrix[rows, cols] = word[i];
                        i++;
                    }
                }
                else
                {
                    for (int cols = matrix.GetLength(1) - 1; cols >= 0; cols--)
                    {
                        
                        if (i > word.Length-1)
                        {
                            i = 0;
                        }
                        matrix[rows, cols] = word[i];
                        i++;
                    }

                }
            }
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    Console.Write(matrix[j,k]);
                }
                Console.WriteLine();
            }
        }   
    }
}
