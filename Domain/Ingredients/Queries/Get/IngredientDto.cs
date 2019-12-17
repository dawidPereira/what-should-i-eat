using System;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;

namespace Domain.Ingredients.Queries.Get
{
	public class IngredientDto
	{
		public IngredientDto(string name,
			Guid id,
			Allergen allergens,
			Requirement requirements,
			MacroNutrientsSharesCollection macroNutrientsSharesCollection)
		{
			Name = name;
			Id = id;
			Allergens = allergens;
			Requirements = requirements;
			MacroNutrientsSharesCollection = macroNutrientsSharesCollection;
		}
		
		public string Name { get; set; }
		public Guid Id { get; set; }
		public Allergen Allergens { get; set; }
		public Requirement Requirements { get; set; }
		public MacroNutrientsSharesCollection MacroNutrientsSharesCollection { get; set; }

		public static IngredientDto FromIngredient(Ingredient ingredient) => 
			new IngredientDto(ingredient.Name, ingredient.Id, ingredient.Allergens, ingredient.Requirements, ingredient.MacroNutrientsSharesCollection);
	}
}