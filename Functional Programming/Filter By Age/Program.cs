using System;
using System.Collections.Generic;
using System.Linq;

namespace Filter_By_Age
{
     class Program
    {
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public Person(string name,int age)
            {
                this.Name = name;
                this.Age = age;
            }
        }

        static void Main(string[] args)
        {
            List<Person> input = new List<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string[] line = Console.ReadLine().Split(", ");
                input.Add(new Person(line[0], int.Parse(line[1])));
            }
            string olderOrYounger = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string pattern = Console.ReadLine();
            Predicate<string> youngerOrOlder = x => x == "younger";
            if (youngerOrOlder(olderOrYounger))
            {
                Func<int,List<Person>,List<Person>> younger = (x,y) => y.Where(t=>t.Age<age).ToList();
                switch (pattern)
                {
                    case "name":
                        younger(age, input).ForEach(x => Console.WriteLine(x.Name));
                        break;
                    case "name age":
                        younger(age, input).ForEach(x => Console.WriteLine(x.Name + " - " + x.Age));
                        break;
                    case "age":
                        younger(age, input).ForEach(x => Console.WriteLine(x.Age));
                        break;
                }
            }
            else
            {
                Func<int, List<Person>, List<Person>> older = (x, y) => y.Where(t => t.Age >= age).ToList();
                switch(pattern)
                {
                    case "name":
                        older(age, input).ForEach(x => Console.WriteLine(x.Name));
                        break;
                    case "name age":
                        older(age, input).ForEach(x => Console.WriteLine(x.Name + " - "+ x.Age));
                        break;
                    case "age":
                        older(age, input).ForEach(x => Console.WriteLine(x.Age));
                        break;
                }
                
            }
            
        }
    }
}
