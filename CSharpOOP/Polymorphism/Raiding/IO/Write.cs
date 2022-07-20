namespace Raiding.IO
{
    using System;
    public class Write : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
