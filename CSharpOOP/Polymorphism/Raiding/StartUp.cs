namespace Raiding
{
    using IO;
    using Core;
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new Read();
            IWriter writer = new Write();
            Engine engine = new Engine(reader,writer);
            engine.Start();
        }
    }
}
