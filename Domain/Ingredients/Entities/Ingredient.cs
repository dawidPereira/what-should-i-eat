using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Common.Extensions;
using Domain.Common.Mediators.Events;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Entities.MacroNutrients;
using Domain.Ingredients.Events;
using Domain.Ingredients.Factories;
using Domain.Ingredients.Repositories;

namespace Domain.Ingredients.Entities
{
	public class Ingredient : IAggregateRoot<Ingredient, Guid>
	{
		private readonly IEventPublisher _eventPublisher;
		private readonly IIngredientRepository _ingredientRepository;

		private Ingredient(
			Identity<Guid> id,
			string name,
			Allergen allergens,
			Requirement requirements,
			IEnumerable<MacroNutrientShare> shares,
			IEventPublisher eventPublisher, 
			IIngredientRepository ingredientRepository)
		{
			Id = SetId(id);
			Name = SetName(name);
			Allergens = allergens;
			Requirements = requirements;
			MacroNutrientsSharesCollection = new MacroNutrientsSharesCollection(shares);
			_eventPublisher = eventPublisher;
			_ingredientRepository = ingredientRepository;
		}

		public Identity<Guid> Id { get; }
		public string Name { get; private set; }
		public Allergen Allergens { get; private set; }
		public Requirement Requirements { get; private set; }
		public MacroNutrientsSharesCollection MacroNutrientsSharesCollection { get; private set; }

		public double CalculateCalories(double grams) =>
			MacroNutrientsSharesCollection.Sum(x => x.MacroNutrient.CalculateCalories(x.Share * grams));

		public IDictionary<MacroNutrient, double> GetMacroNutrientQuantity(double grams)
		{
			var result = MacroNutrientsSharesCollection.ToDictionary(
				x => x.MacroNutrient,
				x => x.Share * grams);
			
			return result;
		}

		public void Update(string name, Allergen allergens, Requirement requirements, IEnumerable<MacroNutrientShare> shares)
		{
			Name = SetName(name);
			Allergens = allergens;
			Requirements = requirements;
			MacroNutrientsSharesCollection = new MacroNutrientsSharesCollection(shares);
			Update();
		}

		public void Delete()
		{
			var @event = new IngredientDeletedEvent(Id, EventsQueue.IngredientDeleted);
			_ingredientRepository.Remove(this);
			_ingredientRepository.Commit();
			_eventPublisher.Publish(@event);
		}

		public bool Equals(Ingredient other) => !ReferenceEquals(null, other) && Id.Equals(other.Id);

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((Ingredient) obj);
		}

		public override int GetHashCode() => Id.GetHashCode();

		private void Update()
		{
			var @event = new IngredientUpdatedEvent(Id, EventsQueue.IngredientUpdated);
			_ingredientRepository.Commit();
			_eventPublisher.Publish(@event);
		}

		private void Create()
		{
			var @event = new IngredientCreatedEvent(Id, EventsQueue.IngredientCreated);
			_ingredientRepository.Add(this);
			_ingredientRepository.Commit();
			_eventPublisher.Publish(@event);
		}

		private static string SetName(string name)
		{
			if (name == null)
				throw new ArgumentNullException(nameof(name), "Ingredient name can not be empty.");
			return name;
		}

		private static Identity<Guid> SetId(Identity<Guid> id)
		{
			if (!id.Value.HasGuidValue())
				throw new ArgumentException("Incorrect guid value.");
			return id;
		}
		
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
				IEventPublisher eventPublisher)
			{
				var ingredient =  !_ingredientRepository.ExistByName(name)
					? new Ingredient(id, name, allergens, requirements, shares, eventPublisher, _ingredientRepository)
					: throw new ArgumentException($"Ingredient with name: '{name}' already exist.");
				ingredient.Create();
				return ingredient;
			}
		}
	}
}