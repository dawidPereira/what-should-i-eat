using System;
using Domain.Common.Mediators.Events;
using Domain.Ingredients.Entities.MacroNutirents;
using Domain.Ingredients.Repositories;

namespace Domain.Ingredients.Entities.Factories
{
	public class IngredientFactory : IIngredientFactory
	{
		private readonly IIngredientRepository _ingredientRepository;

		public IngredientFactory(IIngredientRepository ingredientRepository) => 
			_ingredientRepository = ingredientRepository;

		public Ingredient Create(
			Guid id,
			string name,
			Allergen allergens,
			Requirement requirements,
			MacroNutrientsShares macroNutrientsShares,
			IEventPublisher eventPublisher) =>
			_ingredientRepository.ExistByName(name)
				? new Ingredient(id, name, allergens, requirements, macroNutrientsShares, eventPublisher)
				: throw new ArgumentException($"Ingredient with {name} already exist.");
	}
}