using System;
using System.Numerics;

namespace Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n  = int.Parse(Console.ReadLine());
            BigInteger[][] matrix = new BigInteger[n][];
            for (int i = 0; i < n; i++)
            {
                 matrix[i]= new BigInteger[i+1]; 
            }
            for (int i = 0 ; i < n; i++)
            {
                for (int k = 0; k <= i; k++)
                {
                    if (k == 0 || k == i) matrix[i][k] =  1 ;
                    else
                    matrix[i][k] = matrix[i-1][k-1] + matrix[i-1][k];    
                }
                Console.WriteLine(String.Join(" ",matrix[i]));
            }
        }
    }
}
