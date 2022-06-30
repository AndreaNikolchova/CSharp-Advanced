using System;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        public List<T> List = new List<T>();
        public ListyIterator(List<T> list)
        {
            this.List = list;
        }
        public int CurrentIndex = 0;
        public bool Move()
        {
            if (CurrentIndex + 1 < List.Count)
            {
                CurrentIndex++;
                return true;
            }
            return false;
        }
        public bool HasNext()
        {
            if (CurrentIndex + 1 < List.Count)
                return true;
            return false;
        }
        public void Print()
        {
            if (List.Count==0)
            {
                Console.WriteLine("Invalid Operation!");
                return;
            }
            Console.WriteLine(List[CurrentIndex]);
        }
    }
}
