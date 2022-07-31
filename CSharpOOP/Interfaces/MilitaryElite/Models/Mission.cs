namespace MilitaryElite.Models
{
    public class Mission
    {
        public Mission(string codeName,string state)
        {
            this.CodeName = codeName;
            this.state = state;
        }
        public string CodeName { get; private set; }
        private string state;
        public string State 
        {
            get
            {
               return this.state;
            }
            private set
            {
                if (value != "inProgress" && value != "Finished")
                {
                    throw new InvalidState("Invalid state of Mission!!!");
                }
                this.state = value;
            } 
        }
        public void CompleteMission()
        {

        }

        
    }
}
