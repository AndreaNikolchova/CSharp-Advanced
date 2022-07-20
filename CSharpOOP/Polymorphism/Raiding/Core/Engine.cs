
namespace Raiding.Core
{
    using Models;
    using IO;
    using System.Collections.Generic;

    public class Engine : IEngine
    {
       
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly List<BaseHero> heroCollection;
        
        private Engine()
        {
            this.heroCollection = new List<BaseHero>();
        }
        public Engine(IReader reader, IWriter writer) : 
            this()
        {
            this.writer = writer;
            this.reader = reader;
        }
        public void Start()
        {
            int number = int.Parse(reader.ReadLine());
            while (true)
            {
                string name = reader.ReadLine();
                string type = reader.ReadLine();
                switch(type)
                {
                    case "Druid":
                        BaseHero druid = new Druid(name);
                        heroCollection.Add(druid);
                        break;
                    case "Paladin":
                        BaseHero paladin = new Paladin(name);
                        heroCollection.Add(paladin);
                        break;
                    case "Rogue":
                        BaseHero rogue = new Rogue(name);
                        heroCollection.Add(rogue);
                        break;
                    case "Warrior":
                        BaseHero warrior = new Warrior(name);
                        heroCollection.Add(warrior);
                        break;
                    default:
                        writer.WriteLine("Invalid hero!");
                        break;

                }
                if (this.heroCollection.Count==number)
                {
                    break;
                }
            }
            int bossHealth = int.Parse(reader.ReadLine());
            int powerOfAllHeros = 0;
            foreach(BaseHero hero in heroCollection)
            {
                powerOfAllHeros += hero.Power;
                writer.WriteLine(hero.CastAbility());
            }
            if (powerOfAllHeros >= bossHealth)
                writer.WriteLine("Victory!");
            else
                writer.WriteLine("Defeat...");
        }
    }
}
