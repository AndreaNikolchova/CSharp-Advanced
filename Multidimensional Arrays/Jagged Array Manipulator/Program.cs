using System;
using System.Linq;

namespace Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int[][] matrix = new int[num][];
            for (int i = 0; i < num; i++)
            {
                matrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }
            for (int i = 0; i <num-1; i++)
            {
                if (matrix[i].Length==matrix[i+1].Length)
                {
                    for (int k = i; k < i+2; k++)
                    {
                        for (int j = 0; j < matrix[k].Length; j++)
                        {
                            matrix[k][j] *= 2;
                        }
                    }
                }
                else
                {
                    for (int k = i; k < i + 2; k++)
                    {
                        for (int j = 0; j < matrix[k].Length; j++)
                        {
                            matrix[k][j] /= 2;
                        }
                    }
                }
            }
            while (true)
            {
                string[] command = Console.ReadLine().Split();
                if (command[0] == "End")
                {
                    for (int i = 0; i < num; i++)
                    {
                        Console.WriteLine(String.Join(" ", matrix[i]));
                    }
                    return;
                }
                if (command[0] == "Add")
                if (int.Parse(command[1])>=0&& int.Parse(command[1])<num&& int.Parse(command[2])>=0&& int.Parse(command[2])<matrix[int.Parse(command[1])].Length)
                        matrix[int.Parse(command[1])][int.Parse(command[2])] += int.Parse(command[3]);
                if(command[0] == "Subtract")
                    if (int.Parse(command[1]) >= 0 && int.Parse(command[1]) < num && int.Parse(command[2]) >= 0 && int.Parse(command[2]) < matrix[int.Parse(command[1])].Length)
                        matrix[int.Parse(command[1])][int.Parse(command[2])] -= int.Parse(command[3]);
            }
           
        }
    }
}
