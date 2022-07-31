namespace MilitaryElite.Models
{
    public class Spy : Soldier
    {
        public Spy(string id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
        {
        }
        public int CodeNumber { get; private set; }
    }
}
