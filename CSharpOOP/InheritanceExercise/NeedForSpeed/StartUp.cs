namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RaceMotorcycle motorcycle = new RaceMotorcycle(300, 100);
            motorcycle.Drive(10);
           double fuel =  motorcycle.Fuel;
        }
    }
}
