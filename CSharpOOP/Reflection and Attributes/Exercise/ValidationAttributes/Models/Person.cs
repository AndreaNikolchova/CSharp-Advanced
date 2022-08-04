namespace ValidationAttributes
{
    public class Person
    {
        private const int AgeMinRange = 12;
        private const int AgeMaxRange = 90;
        public Person(string name , int age)
        {
            this.FullName = name;
            this.Age = age;
        }
        [MyRequired]
        public string FullName { get; set; }

        [MyRange(AgeMinRange,AgeMaxRange)]
        public int Age {get; set;}
    }
}
