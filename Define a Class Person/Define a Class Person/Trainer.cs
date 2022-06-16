using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int badges;

        public int Badges
        {
            get { return badges; }
            set { badges = value; }
        }
        public List<Pokemon> pokemons = new List<Pokemon>();
        public Trainer(string name, string pokemonName, string pokemonElement, int pokemonHealth)
        {
            this.Name = name;
            this.Badges = 0;
            Pokemon pokemon =  new Pokemon(pokemonName,pokemonElement,pokemonHealth);
            pokemons.Add(pokemon);
        }
        public bool CheckPokemonElement(string command, Trainer trainer)
        {
            foreach (var pokemon in trainer.pokemons)
            {
                if (pokemon.Element == command)
                {
                    trainer.Badges += 1;
                    return false;
                }
            }
           return true;    
        }
        public List<Pokemon> PokimonsReducingHealt(Trainer trainer)
        {
            foreach (var t in trainer.pokemons)
                t.Health -= 10;
            return trainer.pokemons = trainer.pokemons.Where(x=> x.Health > 0).ToList();
        }   

    }
}
