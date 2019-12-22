using System;
using System.Collections.Generic;
using Domain.Common.Extensions;
using Domain.Common.Mediators.Events;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;
using Domain.Recipes.Events.Created;
using Domain.Recipes.Events.Deleted;
using Domain.Recipes.Factories;
using Domain.Recipes.Repositories;

namespace Domain.Recipes.Entities
{
	public class Recipe : IAggregateRoot<Recipe, Guid>
	{
		private readonly IEventPublisher _eventPublisher;
		private readonly IRecipeRepository _recipeRepository;
		private Recipe(Identity<Guid> id,
			string name,
			string description,
			RecipeDetails recipeDetails,
			IEnumerable<RecipeIngredient> recipeIngredients,
			IEventPublisher eventPublisher,
			IRecipeRepository recipeRepository)
		{
			Id = id;
			Name = name;
			Description = description;
			RecipeDetails = recipeDetails;
			RecipeIngredients = new RecipeIngredientsCollection(recipeIngredients);
			_eventPublisher = eventPublisher;
			_recipeRepository = recipeRepository;
		}

		public Identity<Guid> Id { get; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public RecipeDetails RecipeDetails { get; private set; }
		public RecipeIngredientsCollection RecipeIngredients { get; private set; }


		public void Update(string name, string description, RecipeDetails details, IEnumerable<RecipeIngredient> ingredients)
		{
			Name = SetName(name);
			Description = SetDescription(description);
			RecipeDetails = details;
			RecipeIngredients = new RecipeIngredientsCollection(ingredients);
			Update();
		}

		public bool Equals(Recipe other) => !ReferenceEquals(null, other) && Id.Equals(other.Id);

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((Recipe) obj);
		}

		public override int GetHashCode() => Id.GetHashCode();
		
		public void Delete()
		{
			var @event = new RecipeDeletedEvent(Id, EventsQueue.IngredientDeleted);
			_recipeRepository.Remove(this);
			_recipeRepository.Commit();
			_eventPublisher.Publish(@event);
		}
		
		private void Update()
		{
			var @event = new RecipeCreatedEvent(Id, EventsQueue.IngredientUpdated);
			_recipeRepository.Commit();
			_eventPublisher.Publish(@event);
		}

		private void Create()
		{
			var @event = new RecipeCreatedEvent(Id, EventsQueue.IngredientCreated);
			_recipeRepository.Add(this);
			_recipeRepository.Commit();
			_eventPublisher.Publish(@event);
		}
		
		private static string SetName(string name)
		{
			if (name == null)
				throw new ArgumentNullException(nameof(name), "Recipe name can not be empty.");
			return name;
		}
		
		private static string SetDescription(string description)
		{
			if (description == null)
				throw new ArgumentNullException(nameof(description), "Recipe description can not be empty.");
			return description;
		}

		public class RecipeFactory : IRecipeFactory
		{
			private readonly IRecipeRepository _recipeRepository;
			private readonly IEventPublisher _eventPublisher;

			public RecipeFactory(IRecipeRepository recipeRepository, IEventPublisher eventPublisher)
			{
				_recipeRepository = recipeRepository;
				_eventPublisher = eventPublisher;
			}

			public Recipe Create(Guid id, 
				string name, 
				string description,
				RecipeDetails recipeDetails,
				IEnumerable<RecipeIngredient> recipeIngredients,
				IEventPublisher eventPublisher,
				IRecipeRepository recipeRepository)
			{
				var recipeId = new Identity<Guid>(id);
				var recipe =  new Recipe(recipeId, 
					name, 
					description, 
					recipeDetails, 
					recipeIngredients, 
					eventPublisher, 
					recipeRepository);
				recipe.Create();
				return recipe;
			}
		}
		
	}
}