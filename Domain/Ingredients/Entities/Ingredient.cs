using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Common.Extensions;
using Domain.Common.Mediators.Events;
using Domain.Ingredients.Entities.MacroNutrients;
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
			IEnumerable<MacroNutrientShare> shares,
			IEventPublisher eventPublisher)
		{
			Id = SetId(id);
			Name = SetName(name);
			Allergens = allergens;
			Requirements = requirements;
			MacroNutrientsSharesCollection = new MacroNutrientsSharesCollection(shares);
			_eventPublisher = eventPublisher;
			
			var @event = new IngredientCreatedEvent(id, EventsQueue.IngredientCreated);
			_eventPublisher.Publish(@event);
		}

		public Guid Id { get; }
		public string Name { get; private set; }
		public Allergen Allergens { get; private set; }
		public Requirement Requirements { get; private set; }
		public MacroNutrientsSharesCollection MacroNutrientsSharesCollection { get; private set; }

		public void Update(string name, Allergen allergens, Requirement requirements, IEnumerable<MacroNutrientShare> shares)
		{
			Name = SetName(name);
			Allergens = allergens;
			Requirements = requirements;
			MacroNutrientsSharesCollection = new MacroNutrientsSharesCollection(shares);
			
			var @event = new IngredientUpdatedEvent(Id, EventsQueue.IngredientUpdated);
			_eventPublisher.Publish(@event);
		}

		public double CalculateCalories(double grams) =>
			MacroNutrientsSharesCollection.Sum(x => x.MacroNutrient.CalculateCalories(x.Share * grams));

		public IDictionary<MacroNutrient, double> GetMacroNutrientQuantity(double grams)
		{
			var result = MacroNutrientsSharesCollection.ToDictionary(
				x => x.MacroNutrient,
				x => x.Share * grams);
			
			return result;
		}

		private static Guid SetId(Guid id)
		{
			if (!id.HasGuidValue())
				throw new ArgumentException("Incorrect guid value.");
			return id;
		}

		private static string SetName(string name)
		{
			if (name == null)
				throw new ArgumentNullException(nameof(name), "Ingredient name can not be empty.");
			return name;
		}
	}
}