using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Entities.Ingredient
{
	public sealed class Ingredient
	{
		public Ingredient(Guid id, string name, int allergens, int requirements, ICollection<MacroNutrientShares> macroNutrientShares)
		{
			Id = id;
			Name = name;
			Allergens = allergens;
			Requirements = requirements;
			MacroNutrientsShares = macroNutrientShares;
		}
		
		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public int Allergens { get; private set; }
		public int Requirements { get;  private set; }
		public ICollection<MacroNutrientShares> MacroNutrientsShares { get;  private set; }

		public static Ingredient FromDomainIngredient(Domain.Ingredients.Entities.Ingredient ingredient) =>
			new Ingredient(ingredient.Id.Value,
				ingredient.Name,
				(int)ingredient.Allergens,
				(int)ingredient.Requirements,
				GetMacroNutrientShares(ingredient));

		private static ICollection<MacroNutrientShares> GetMacroNutrientShares(Domain.Ingredients.Entities.Ingredient ingredient)
		{
			var sharesCollection = ingredient.MacroNutrientsSharesCollection;
			return sharesCollection.Select(x =>  MacroNutrientShares.FromDomainIngredient(ingredient.Id.Value, x))
				.ToList();
		}
	}
}