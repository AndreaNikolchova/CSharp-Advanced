using System;
using System.Linq;

namespace Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int[,] matrix = new int[num, num];
            for (int i = 0; i < num; i++)
            {
                int[] row = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int k = 0; k < num; k++)
                {
                    matrix[i, k] = row[k];
                }
            }
            int sum = 0;
            int sum1 = 0;
            for (int i = 0; i < num; i++)
            {
                for (int k = 0; k < num; k++)
                {
                    if (i == k)
                    {
                        sum += matrix[i, k];
                    }
                }
            }
            for (int i = 0; i < num; i++)
            {
                for (int k = 0; k < num; k++)
                {
                    if ((i + k) == (num - 1))
                    {
                        sum1 += matrix[i, k];
                    }
                }
            }
            if (sum1 > sum)
            {
                Console.WriteLine(sum1 - sum);
            }
            else Console.WriteLine(sum-sum1);

        }
    }
}
