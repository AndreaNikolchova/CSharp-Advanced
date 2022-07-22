using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray().ToList();
            int countOfExeptions = 0;
            while (true)
            {
                if (countOfExeptions==3)
                {
                    Console.WriteLine(String.Join(", ",numbers));
                    return;
                }
                string[] line = Console.ReadLine().Split(' ');
                try
                {
                    switch(line[0])
                    {
                        case "Replace":
                            Replace(int.Parse(line[1]), int.Parse(line[2]),numbers);
                            break;
                        case "Print":
                            Print(int.Parse(line[1]), int.Parse(line[2]), numbers);
                            break;
                        case "Show":
                            Show(int.Parse(line[1]),numbers);
                            break;
                    }
                }
                catch (FormatException)
                {
                    countOfExeptions++;
                    Console.WriteLine("The variable is not in the correct format!");
                }
                catch(Exception)
                {
                    countOfExeptions++;
                    Console.WriteLine("The index does not exist!");
                }
            }
        }

        private static void Show(int index, List<int> numbers)
        {
            if (index<0&&index>=numbers.Count)
            {
                throw new Exception();
            }
            Console.WriteLine(numbers[index]);
        }

        private static void Print(int indexStart, int indexEnd, List<int> numbers)
        {
            if (indexStart < 0 && indexStart >= numbers.Count || indexEnd<0&&indexEnd>=numbers.Count)
            {
                throw new Exception();
            }
            else
            {
                List<int> print = new List<int>();
                for (int i = indexStart; i <= indexEnd; i++)
                    print.Add(numbers[i]);
                Console.WriteLine(String.Join(", ",print));     
            }
        }

        private static void Replace(int index, int replacement,List<int> array)
        {
            if (index<0&&index>=array.Count)
            {
                throw new Exception();
            }
            else
            {
                array[index] = replacement;
            }
        }
    }
}
