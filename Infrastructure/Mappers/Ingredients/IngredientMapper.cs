using System.Collections.Generic;
using System.Linq;
using Domain.Events;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;
using Domain.Ingredients.Repositories;
using Infrastructure.Common.Extensions;
using Infrastructure.Entities.Ingredient;
using Ingredient = Infrastructure.Entities.Ingredients.Ingredient;

namespace Infrastructure.Mappers.Ingredients
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
				ingredient.Allergens.ToEnum<Allergen>(),
				ingredient.Requirements.ToEnum<Requirement>(),
				GetMacroNutrientShares(ingredient.MacroNutrientsShares));
		}

		private static IEnumerable<MacroNutrientShare> GetMacroNutrientShares(IEnumerable<MacroNutrientShares> macroNutrientShares)
		{
			return macroNutrientShares.Select(x => new MacroNutrientShare(x.MacroNutrient.ToEnum<MacroNutrient>(), x.Share))
				.ToList();
		}
	}
}