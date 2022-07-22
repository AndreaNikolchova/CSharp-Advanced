using System;
using System.Collections.Generic;

namespace MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { '-', ',' });
            Dictionary<int, double> bankAccount = new Dictionary<int, double>();
            for (int i = 0; i < input.Length-1; i += 2)
                bankAccount.Add(int.Parse(input[i]), double.Parse(input[i + 1]));
            while (true)
            {
                string[] command = Console.ReadLine().Split(' ');
                if (command[0] == "End")
                {
                    break;
                }
                try
                {
                    switch (command[0])
                    {
                        case "Deposit":
                            if (!bankAccount.ContainsKey(int.Parse(command[1])))
                                throw new ArgumentException("Invalid account!");
                            bankAccount[int.Parse(command[1])] += double.Parse(command[2]);
                            break;
                        case "Withdraw":
                            if (!bankAccount.ContainsKey(int.Parse(command[1])))
                                throw new ArgumentException("Invalid account!");
                            if (bankAccount[int.Parse(command[1])] < double.Parse(command[2]))
                                throw new ArgumentException("Insufficient balance!");
                            bankAccount[int.Parse(command[1])] -= double.Parse(command[2]);
                            break;
                        default:
                            throw new ArgumentException("Invalid command!");
                    }
                    Console.WriteLine($"Account {command[1]} has new balance: {bankAccount[int.Parse(command[1])]:f2}");

                }
                catch (ArgumentException ae)
                { Console.WriteLine(ae.Message); }
                finally { Console.WriteLine("Enter another command"); }
            }
        
        }
    }
}
