using System;
using System.Linq;

namespace Jagged_Array_Modification
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
            while (true)
            {
                string[] command = Console.ReadLine().Split(" ");
                switch (command[0])
                {
                    case "Add":
                        if (int.Parse(command[1])>=0&& int.Parse(command[1])<num&& int.Parse(command[2])>=0&& int.Parse(command[2])<matrix[int.Parse(command[1])].Length)
                        {
                            matrix[int.Parse(command[1])][int.Parse(command[2])] += int.Parse(command[3]);
                        }
                        else
                        Console.WriteLine("Invalid coordinates");
                        break;
                    case "Subtract":
                        if (int.Parse(command[1]) >= 0 && int.Parse(command[1]) < num && int.Parse(command[2]) >= 0 && int.Parse(command[2]) < matrix[int.Parse(command[1])].Length)
                        {
                            matrix[int.Parse(command[1])][int.Parse(command[2])] -= int.Parse(command[3]);
                        }
                        else
                        Console.WriteLine("Invalid coordinates");
                         break;
                    case "END":
                       foreach(var row in matrix)
                        {
                            Console.WriteLine(String.Join(" ",row));
                        }
                        return;
                }

            }
        }
    }
}
