namespace ExplicitInterfaces
{
    using System;
    using ExplicitInterfaces.Modals.Interfaces;
    using Modals;
    public class StartUp
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split(' ');
                if (input[0] == "End") return;
                IPerson person = new Citizen(input[0],input[1],int.Parse(input[2]));
                IResident resident = new Citizen(input[0], input[1], int.Parse(input[2]));
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
