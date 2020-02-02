using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;
using Domain.Recipes.Entities;
using Domain.RecipesDetails.Entities;

namespace Domain.RecipesDetails.Queries.Find
{
	public class RecipeDetailsDto
	{
		private RecipeDetailsDto(Guid id,
			string name,
			Requirement requirements,
			Allergen allergens,
			MealType mealTypes,
			double calories,
			IDictionary<MacroNutrient, double> macroNutrientQuantity)
		{
			Id = id;
			Name = name;
			Requirements = requirements.ToString();
			Allergens = allergens.ToString();
			MealTypes = mealTypes.ToString();
			Calories = calories;
			MacroNutrientQuantity = GetMacroNutrientQuantity(macroNutrientQuantity);
		}

		public Guid Id { get; }
		public string Name { get; }
		public string Requirements { get; }
		public string Allergens { get; }
		public string MealTypes { get; }
		public double Calories { get; }
		public IDictionary<string, double> MacroNutrientQuantity { get; }

		public static RecipeDetailsDto FromRecipeDetails(RecipeDetails recipesDetails) =>
			new RecipeDetailsDto(recipesDetails.Id.Value,
				recipesDetails.Name,
				recipesDetails.Requirements,
				recipesDetails.Allergens,
				recipesDetails.MealTypes,
				recipesDetails.Calories,
				recipesDetails.MacroNutrientQuantity);

		private static IDictionary<string, double> GetMacroNutrientQuantity(
			IDictionary<MacroNutrient, double> macroNutrientQuantity) => macroNutrientQuantity
			.Select(x => new KeyValuePair<string, double>(x.Key.ToString(), x.Value))
			.ToDictionary(x => x.Key, x => x.Value);
	}
}