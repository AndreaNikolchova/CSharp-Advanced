namespace MilitaryElite.Models
{
    public class Private : Soldier
    {
        public Private(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; protected set; }
    }
}
