using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> member = new List<Person>();
        public void AddMember(Person person)
        {
            member.Add(person);
        }
        public Person GetOldestMember()
        {
            int maxAge = int.MinValue;
            Person oldestPerson = new Person();
            foreach (Person person in member)
            {
                if (person.Age > maxAge)
                {
                    maxAge = person.Age;
                    oldestPerson = person;
                }
            }
            return oldestPerson;
        }

    }
}
