using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] info = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Trainer trainer = trainers.FirstOrDefault(x => x.Name == info[0]);
                if (trainer != null)
                {
                    trainer.Pokemons.Add(new Pokemon(info[1], info[2], double.Parse(info[3]))); 
                }
                else
                {
                    trainer = new Trainer(info[0]);
                    trainer.Pokemons.Add(new Pokemon(info[1], info[2], double.Parse(info[3])));
                    trainers.Add(trainer);
                }
            }
            while ((input = Console.ReadLine()) != "End")
            {
                switch (input)
                {
                    case "Fire":
                        TrainerCheckElements(trainers, input);
                        break;
                    case "Water":
                        TrainerCheckElements(trainers, input);
                        break;
                    case "Electricity":
                        TrainerCheckElements(trainers, input);
                        break;
                }
            }
            foreach (var trener in trainers.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{trener.Name} {trener.Badges} {trener.Pokemons.Count}");
            }
        }

        private static void TrainerCheckElements(List<Trainer> trainers, string input)
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(x => x.Element == input))
                {
                    trainer.Badges++;
                }
                else
                {
                    foreach (var pokemon in trainer.Pokemons)
                    {
                        pokemon.Health -= 10;
                    }
                }
                if (trainer.Pokemons.Any(x => x.Health <= 0))
                {
                    trainer.Pokemons.RemoveAll(x => x.Health <= 0);
                }
            }
        }
    }
}