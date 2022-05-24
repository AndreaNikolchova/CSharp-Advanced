using System;
using System.Linq;

namespace Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string[,] matrix = new string[input[0], input[1]];
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                string[] row1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = row1[cols];
                }
            }
            while (true)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "END") return;
                if (command[0]== "swap" && command.Length==5 && int.Parse(command[1]) >= 0 && int.Parse(command[1]) < input[0]&& int.Parse(command[2]) >= 0&& int.Parse(command[2]) < input[1] && int.Parse(command[3]) >= 0 && int.Parse(command[3]) < input[0] && int.Parse(command[4]) >= 0 && int.Parse(command[4]) < input[1])
                {
                    int row1 = int.Parse(command[1]);
                    int col1 = int.Parse(command[2]);
                    int row2 = int.Parse(command[3]);
                    int col2 = int.Parse(command[4]);
                    string first = matrix[row1, col1];
                    string second = matrix[row2, col2];
                    matrix[row1, col1] = second;
                    matrix[row2, col2] = first;
                    for (int rows = 0; rows < matrix.GetLength(0); rows++)
                    {
                       
                        for (int cols = 0; cols < matrix.GetLength(1); cols++)
                        {
                            Console.Write(matrix[rows,cols] + " ");
                        }
                        Console.WriteLine();
                    }
                    
                }
                else Console.WriteLine("Invalid input!");
                
            }
        }
    }
}
