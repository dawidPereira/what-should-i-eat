using System;
using Domain.Ingredients.Entities.MacroNutirents;

namespace Domain.Ingredients.Entities.Factories
{
	public interface IIngredientFactory
	{
		Ingredient Create(
			Guid id, string name, Allergen allergens, Requirement requirements, MacroNutrientsShares macroNutrientsShares);
	}
}