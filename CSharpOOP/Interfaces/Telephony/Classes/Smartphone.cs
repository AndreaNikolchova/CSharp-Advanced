using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public void Browsing(string site)
        {
            Console.WriteLine($"Browsing: {site}!");
        }

        public void Calling(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
    }
}
