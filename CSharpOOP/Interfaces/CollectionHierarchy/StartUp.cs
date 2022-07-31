namespace CollectionHierarchy
{
    using System;
    using Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
           string[] input = Console.ReadLine().Split(' ');
            int num = int.Parse(Console.ReadLine());
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection removeCollection = new AddRemoveCollection();
            MyList myList = new MyList();
           foreach(string inputItem in input)
               Console.Write(addCollection.Add(inputItem)+ " ");
            Console.WriteLine();
            foreach (string inputItem in input)
                Console.Write(removeCollection.Add(inputItem) + " ");
            Console.WriteLine();
            foreach (string inputItem in input)
                Console.Write(myList.Add(inputItem) + " ");
            Console.WriteLine();
            for (int i = 1; i <= num; i++)
                Console.Write(removeCollection.Remove() + " ");
            Console.WriteLine();
            for (int i = 1; i <= num; i++)
                Console.Write(myList.Remove() + " ");
        }
    }
}
