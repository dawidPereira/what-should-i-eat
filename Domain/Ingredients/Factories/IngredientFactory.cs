using System;
using System.Collections.Generic;
using Domain.Common.Mediators.Events;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;
using Domain.Ingredients.Repositories;

namespace Domain.Ingredients.Factories
{
	public class IngredientFactory : IIngredientFactory
	{
		private readonly IIngredientRepository _ingredientRepository;

		public IngredientFactory(IIngredientRepository ingredientRepository) => 
			_ingredientRepository = ingredientRepository;

		public Ingredient Create(
			Identity<Guid> id,
			string name,
			Allergen allergens,
			Requirement requirements,
			IEnumerable<MacroNutrientShare> shares,
			IEventPublisher eventPublisher) =>
			_ingredientRepository.ExistByName(name)
				? new Ingredient(id, name, allergens, requirements, shares, eventPublisher)
				: throw new ArgumentException($"Ingredient with {name} already exist.");
	}
}