using System;

namespace SquareRoot
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number<0)
                {
                    throw new Exception();
                }
                Console.WriteLine(Math.Sqrt(number));

            }
            catch 
            {
                Console.WriteLine("Invalid number.");
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
