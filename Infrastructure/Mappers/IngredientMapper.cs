using System.Collections.Generic;
using System.Linq;
using Domain.Common.Mediators.Events;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;
using Domain.Ingredients.Repositories;
using Infrastructure.Entities.Ingredient;
using Ingredient = Infrastructure.Entities.Ingredients.Ingredient;

namespace Infrastructure.Mappers
{
	public class IngredientMapper : IIngredientMapper
	{
		private readonly IEventPublisher _eventPublisher;
		private readonly IIngredientRepository _ingredientRepository;

		public IngredientMapper(IIngredientRepository ingredientRepository, IEventPublisher eventPublisher)
		{
			_ingredientRepository = ingredientRepository;
			_eventPublisher = eventPublisher;
		}

		public Domain.Ingredients.Entities.Ingredient ToDomainIngredient(Ingredient ingredient)
		{
			var ingredientFactory = new Domain.Ingredients.Entities.Ingredient.IngredientFactory(_ingredientRepository, _eventPublisher);
			return ingredientFactory.Create(ingredient.Id,
				ingredient.Name,
				(Allergen) ingredient.Allergens,
				(Requirement) ingredient.Requirements,
				GetMacroNutrientShares(ingredient.MacroNutrientsShares));
		}

		private IEnumerable<MacroNutrientShare> GetMacroNutrientShares(IEnumerable<MacroNutrientShares> macroNutrientShares) 
			=> macroNutrientShares.Select(x => new MacroNutrientShare((MacroNutrient) x.MacroNutrient, x.Share)).ToList();
	}
}