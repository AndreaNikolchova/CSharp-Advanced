using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<string>
    {
        public List<string> array = new List<string>();
        
        public void FillTheArray(params string[] items)
        {
            List<string> odd = new List<string>();
            List<string> even = new List<string>();
            for (int i = 0; i < items.Length; i++)
            {
                if (i%2==0)
                    even.Add(items[i]);
                else
                   odd.Add(items[i]);

            }
            odd.Reverse();
            foreach(string item in even)
            {
                array.Add(item);
            }
            foreach (string item in odd)
            {
                array.Add(item);
            }

        }
        public IEnumerator<string> GetEnumerator()
        {
           foreach (var item in array)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
