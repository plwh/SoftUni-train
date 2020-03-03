using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            string firstInputLine = "";
            while ((firstInputLine = Console.ReadLine()) != "Tournament")
            {
                string[] input = firstInputLine.Split();
                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int pokemonHealth = int.Parse(input[3]);

                Trainer currentTrainer = new Trainer(trainerName);
                Pokemon currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (trainers.Any(a => a.Name == currentTrainer.Name))
                {
                    trainers.Find(a => a.Name == currentTrainer.Name).Pokemons.Add(currentPokemon);
                }
                else
                {
                    currentTrainer.Pokemons.Add(currentPokemon);
                    trainers.Add(currentTrainer);
                }
            }

            string secondInputLine = "";
            while ((secondInputLine = Console.ReadLine()) != "End")
            {
                string currentElement = secondInputLine;
                foreach (Trainer trainer in trainers)
                {
                    if (trainer.Pokemons.Any(a => a.Element == currentElement))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        for(int i = trainer.Pokemons.Count - 1; i >= 0; i--)
                        {
                            Pokemon pokemon = trainer.Pokemons[i];

                            pokemon.Health -= 10;

                            if (pokemon.Health <= 0)
                            {
                                trainer.Pokemons.Remove(pokemon);
                            }
                        }
                    }
                }
            }

            trainers
                .OrderByDescending(a => a.NumberOfBadges)
                .ToList()
                .ForEach(a => Console.WriteLine($"{a.Name} {a.NumberOfBadges} {a.Pokemons.Count}"));
        }
    }
}
