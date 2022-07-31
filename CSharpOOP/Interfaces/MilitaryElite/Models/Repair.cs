namespace MilitaryElite.Models
{
    public class Repair
    {
        public Repair(string name, int hours)
        {
            this.PartName = name;
            this.Hours = hours;
        }
        public string PartName { get; private set; }
        public int Hours { get; private set; }
    }
}
