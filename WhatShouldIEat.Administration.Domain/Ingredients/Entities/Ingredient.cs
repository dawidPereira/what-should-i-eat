using System;
using System.Collections.Generic;
using System.Linq;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.CreateIngredientCommand;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.UpdateIngredientCommand;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;
using WhatShouldIEat.Administration.Domain.Ingredients.Queries.GetIngredientQuery;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Entities
{
	public class Ingredient
	{
		private  Ingredient(Guid id,
			string name,
			HashSet<Allergen> allergens,
			HashSet<Requirements> requirements,
			HashSet<Tuple<MacroNutrient, double>> macroNutrientsPerGram)
		{
			Name = name;
			Id = id;
			Allergens = allergens;
			Requirements = requirements;
			MacroNutrientsPerGram = macroNutrientsPerGram;
		}

		public string Name { get; private set; }
		public Guid Id { get; private set; }
		public HashSet<Allergen> Allergens { get; private set; }
		public HashSet<Requirements> Requirements { get; private set; }
		public HashSet<Tuple<MacroNutrient, double>> MacroNutrientsPerGram { get; private set; }
		public ICollection<RecipeIngredient> RecipeIngredients { get; private set; }

		public static Ingredient Create(CreateIngredientCommand command) => new Ingredient(
				command.Id, 
				command.Name, 
				command.Allergens, 
				command.Requirements, 
				command.MacroNutrients);

		public double CalculateCalories(double grams) =>
			MacroNutrientsPerGram.Sum(x => x.Item1.CalculateCalories(x.Item2 * grams));

		public void Update(UpdateIngredientCommand command)
		{
			Name = command.Name;
			Allergens = command.Allergens;
			Requirements = command.Requirements;
			MacroNutrientsPerGram = command.MacroNutrients;
		}

		public IngredientDto ToDto() => new IngredientDto 
		{
			Id = Id,
			Name = Name,
			Allergens = Allergens,
			Requirements = Requirements,
			MacroNutrientsPerGram = MacroNutrientsPerGram
		};
	}
}