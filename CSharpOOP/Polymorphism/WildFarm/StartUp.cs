namespace WildFarm
{
    using IO;
    using Core;
    public class StartUp
    {
        static void Main(string[] args)
        {
            IWriter writer = new Write();
            IReader reader = new Read();
            Engine engine = new Engine(writer,reader);
            engine.Start();
        }
    }
}
