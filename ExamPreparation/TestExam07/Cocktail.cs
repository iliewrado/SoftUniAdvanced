using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> Ingredients;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel => Ingredients.Sum(x => x.Alcohol);

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Ingredients = new List<Ingredient>();
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
        }

        public void Add(Ingredient ingredient)
        {
            if (Ingredients.Exists(x => x.Name == ingredient.Name) == false
                && Ingredients.Sum(x => x.Alcohol) + ingredient.Alcohol <= MaxAlcoholLevel)
            {
                Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            Ingredient ingredient = Ingredients.FirstOrDefault(x => x.Name == name);
            return Ingredients.Remove(ingredient);
        }

        public Ingredient FindIngredient(string name)
        {
            return Ingredients.FirstOrDefault(x => x.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder cocktailInfo = new StringBuilder();
            cocktailInfo.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (var item in Ingredients)
            {
                cocktailInfo.AppendLine(item.ToString());
            }
            return cocktailInfo.ToString().TrimEnd();
        }
    }
}
