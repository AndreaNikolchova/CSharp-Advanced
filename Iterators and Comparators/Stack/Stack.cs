using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        public List<T>array = new List<T>();
        public void Push(params T[] Item)
        {
            foreach(var item in Item)
            {
                array.Add(item);
            }
        }
        public void Pop()
        {
            if (array.Count<=0)
            {
                Console.WriteLine("No elements");
                return;
            }
            array.RemoveAt(array.Count - 1);
        }
        public IEnumerator<T> GetEnumerator()
        {
           foreach(var item in array)
            {
                yield return item;  
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}
