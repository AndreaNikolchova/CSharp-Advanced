
namespace Vehicles.IO
{
    using System;
    public class Read : IReader
    {
        public string ReadLine()
        {
            string readLine = Console.ReadLine();
            return readLine;
        }
    }
}
