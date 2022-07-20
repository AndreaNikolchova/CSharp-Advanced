using System;
using System.Collections.Generic;

namespace EnterNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            const int End = 100;
            List<int> numbers = new List<int>();
            while (true)
            {
                try
                {
                    if (numbers.Count == 10)
                        break;
                    int number = int.Parse(Console.ReadLine());
                    start = ReadNumber(start,End,number);
                    numbers.Add(number);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch
                {
                    Console.WriteLine("Invalid Number!");
                }
            }
            Console.WriteLine(String.Join(", ",numbers));
            
        }
        public static int ReadNumber(int start, int end, int number)
        {
            if (start>=number||number>=end)
            {
                 throw new ArgumentException($"Your number is not in range {start} - 100!");
            }
            start = number;
            return start;
        }
    }
}
