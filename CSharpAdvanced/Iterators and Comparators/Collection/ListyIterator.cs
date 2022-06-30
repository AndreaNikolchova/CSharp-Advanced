using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        public List<T> List = new List<T>();
        public ListyIterator(List<T> list)
        {
            this.List = list;
        }
        public int CurrentIndex = 0;
        public bool Move()
        {
            if (this.CurrentIndex + 1 < this.List.Count)
            {
                this.CurrentIndex++;
                return true;
            }
            return false;
        }
        public bool HasNext()
        {
            if (this.CurrentIndex + 1 < this.List.Count)
                return true;
            return false;
        }
        public void Print()
        {
            if (List.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
                return;
            }
            Console.WriteLine(List[CurrentIndex]);
        } 
        public void PrintAll()
        { 
            Console.WriteLine(string.Join(" ",List));

        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in List)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}
