using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] people = Console.ReadLine().Split(new char[] { '=',';' }, StringSplitOptions.RemoveEmptyEntries);
            string[] products = Console.ReadLine().Split(new char[] { '=', ';' },StringSplitOptions.RemoveEmptyEntries);
            List<Person> listOfPeople = new List<Person>();
            List<Product> listOfProducts = new List<Product>();
            try
            {
                for (int i = 0; i < people.Length; i += 2)
                    listOfPeople.Add(new Person(people[i], int.Parse(people[i+1])));
                for (int i = 0; i < products.Length; i += 2)
                    listOfProducts.Add(new Product(products[i], int.Parse(products[i + 1])));
                
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }
            while (true)
            {
                string[] nameAndProduct = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                if (nameAndProduct[0] == "END")
                    break;
                int index = listOfPeople.FindIndex(x=>x.Name == nameAndProduct[0]);
                int indexProduct = listOfProducts.FindIndex(x => x.Name == nameAndProduct[1]);
                listOfPeople[index].Check(listOfPeople[index], listOfProducts[indexProduct]);
            }
            foreach (var item in listOfPeople)
            {
                if (item.BagOfProducts.Count == 0)
                    Console.WriteLine(item.Name + " - Nothing bought");
                else
                    Console.WriteLine(item);
            }
        }
    }
}
