using System;
using Domain.Common.Mediators.Events;
using Domain.Ingredients.Entities.MacroNutrients;

namespace Domain.Ingredients.Entities.Factories
{
	public interface IIngredientFactory
	{
		Ingredient Create(Guid id,
			string name,
			Allergen allergens,
			Requirement requirements,
			MacroNutrientsSharesCollection macroNutrientsSharesCollection,
			IEventPublisher eventPublisher);
	}
}