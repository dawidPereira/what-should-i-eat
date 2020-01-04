using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Entities.Ingredient;

namespace Infrastructure.Entities.Ingredients
{
	public sealed class Ingredient
	{
		private Ingredient() {}
		
		public Ingredient(Guid id, string name, string allergens, string requirements, ICollection<MacroNutrientShares> macroNutrientShares)
		{
			Id = id;
			Name = name;
			Allergens = allergens;
			Requirements = requirements;
			MacroNutrientsShares = macroNutrientShares;
		}
		
		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public string Allergens { get; private set; }
		public string Requirements { get;  private set; }
		public ICollection<MacroNutrientShares> MacroNutrientsShares { get;  private set; }

		public static Ingredient FromDomainIngredient(Domain.Ingredients.Entities.Ingredient ingredient) =>
			new Ingredient(ingredient.Id.Value,
				ingredient.Name,
				ingredient.Allergens.ToString(),
				ingredient.Requirements.ToString(),
				GetMacroNutrientShares(ingredient));

		private static ICollection<MacroNutrientShares> GetMacroNutrientShares(Domain.Ingredients.Entities.Ingredient ingredient)
		{
			var sharesCollection = ingredient.MacroNutrientsSharesCollection;
			return sharesCollection.Select(x =>  MacroNutrientShares.FromDomainIngredient(ingredient.Id.Value, x))
				.ToList();
		}
	}
}