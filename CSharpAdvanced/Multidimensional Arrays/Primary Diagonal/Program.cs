using System;
using System.Linq;

namespace Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int[,] matrix = new int [num,num];
            for (int i = 0; i < num; i++)
            {
                int[] row = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int k = 0; k < num; k++)
                {
                    matrix[i, k] = row[k];
                }
            }
            int sum = 0;
            for (int i = 0; i < num; i++)
            {
                for (int k = 0; k < num; k++)
                {
                    if (i==k)
                    {
                        sum+=matrix[i,k];
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
