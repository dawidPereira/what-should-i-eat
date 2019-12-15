using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Common.Extensions;
using Domain.Common.Mediators.Events;
using Domain.Ingredients.Entities.MacroNutirents;
using Domain.Ingredients.Events;

namespace Domain.Ingredients.Entities
{
	public class Ingredient
	{
		private readonly IEventPublisher _eventPublisher;
		public Ingredient(
			Guid id,
			string name,
			Allergen allergens,
			Requirement requirements,
			MacroNutrientsShares macroNutrientsShares, 
			IEventPublisher eventPublisher)
		{
			Id = SetId(id);
			Name = SetName(name);
			Allergens = allergens;
			Requirements = requirements;
			MacroNutrientsShares = macroNutrientsShares;
			_eventPublisher = eventPublisher;
		}

		public Guid Id { get; }
		public string Name { get; }
		public Allergen Allergens { get; }
		public Requirement Requirements { get; }
		public MacroNutrientsShares MacroNutrientsShares { get; }

		public Ingredient Update(Guid id,
			string name,
			Allergen allergens,
			Requirement requirements,
			MacroNutrientsShares macroNutrientsShares)
		{
			var ingredient = new Ingredient(id, name, allergens, requirements, macroNutrientsShares, _eventPublisher);
			_eventPublisher.Publish(new IngredientUpdatedEvent(EventsQueue.IngredientUpdated, ingredient.Id.ToString()));
			return ingredient;
		}
		
		public double CalculateCalories(double grams) =>
			MacroNutrientsShares.Sum(x => x.MacroNutrient.CalculateCalories(x.ParticipationInIngredient * grams));

		public IDictionary<MacroNutrient, double> GetMacroNutrientQuantity(double grams)
		{
			var result = MacroNutrientsShares.ToDictionary(
				x => x.MacroNutrient,
				x => x.ParticipationInIngredient * grams);
			return result;
		}

		private static Guid SetId(Guid id)
		{
			if(!id.HasGuidValue()) 
				throw new ArgumentException("Incorrect guid value.");
			return id;
		}

		private static string SetName(string name)
		{
			if(name == null)
				throw new ArgumentNullException(nameof(name), "Ingredient name can not be empty.");
			return name;
		}
	}
}