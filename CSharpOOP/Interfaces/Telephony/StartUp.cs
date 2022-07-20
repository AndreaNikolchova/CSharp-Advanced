using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ');
            string[] urls = Console.ReadLine().Split(' ');
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();
            foreach (string num in numbers)
                CheckNumber(num,smartphone,stationaryPhone);
            foreach(var url in urls)
                CheckUrl(url, smartphone);
        }

        private static void CheckUrl(string url, Smartphone smartphone)
        {
            foreach (var n in url)
            {
                if (char.IsDigit(n))
                {
                    Console.WriteLine("Invalid URL!");
                    return;
                }
            }
            smartphone.Browsing(url);
        }

        private static void CheckNumber(string num, Smartphone smartphone, StationaryPhone stationaryPhone)
        {
            foreach(var n in num)
            {
                if(!char.IsDigit(n))
                {
                    Console.WriteLine("Invalid number!");
                    return;
                }
            }
            if (num.Length== 10)
            {
                smartphone.Calling(num);
                return;
            }
            else if (num.Length == 7)
            {
                stationaryPhone.Calling(num);
                return;
            }
            else
            {
                Console.WriteLine("Invalid number!");
                return;
            }
        }
    }
}
