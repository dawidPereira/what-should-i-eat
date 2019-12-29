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

		public IngredientMapper( IEventPublisher eventPublisher)
		{
			_eventPublisher = eventPublisher;
		}

		public Domain.Ingredients.Entities.Ingredient ToDomainIngredient(Ingredient ingredient, IIngredientRepository ingredientRepository)
		{
			var ingredientFactory = new Domain.Ingredients.Entities.Ingredient.IngredientFactory(ingredientRepository, _eventPublisher);
			return ingredientFactory.GetIngredient(ingredient.Id,
				ingredient.Name,
				(Allergen) ingredient.Allergens,
				(Requirement) ingredient.Requirements,
				GetMacroNutrientShares(ingredient.MacroNutrientsShares));
		}

		private IEnumerable<MacroNutrientShare> GetMacroNutrientShares(IEnumerable<MacroNutrientShares> macroNutrientShares) 
			=> macroNutrientShares.Select(x => new MacroNutrientShare((MacroNutrient) x.MacroNutrient, x.Share)).ToList();
	}
}