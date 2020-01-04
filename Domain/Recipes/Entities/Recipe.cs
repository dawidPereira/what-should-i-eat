using System;
using System.Collections.Generic;
using Domain.Common.ValueObjects;
using Domain.Events;
using Domain.Recipes.Events.Created;
using Domain.Recipes.Events.Deleted;
using Domain.Recipes.Events.Updated;
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
			RecipeInfo recipeInfo,
			IEnumerable<RecipeIngredient> recipeIngredients,
			IEventPublisher eventPublisher,
			IRecipeRepository recipeRepository)
		{
			Id = id;
			Name = SetName(name);
			Description = SetDescription(description);
			RecipeInfo = recipeInfo;
			RecipeIngredients = new RecipeIngredientsCollection(recipeIngredients);
			_eventPublisher = eventPublisher;
			_recipeRepository = recipeRepository;
		}

		public Identity<Guid> Id { get; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public RecipeInfo RecipeInfo { get; private set; }
		public RecipeIngredientsCollection RecipeIngredients { get; private set; }


		public void Update(string name, string description, RecipeInfo info, IEnumerable<RecipeIngredient> ingredients)
		{
			Name = SetName(name);
			Description = SetDescription(description);
			RecipeInfo = info;
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
			var @event = new RecipeDeletedEventMessage(Id.Value);
			_recipeRepository.Remove(this);
			_recipeRepository.Commit();
			_eventPublisher.Publish(@event);
		}
		
		private void Update()
		{
			var @event = new RecipeUpdatedEventMessage(Id.Value);
			_recipeRepository.Update(this);
			_recipeRepository.Commit();
			_eventPublisher.Publish(@event);
		}

		private void Create()
		{
			var @event = RecipeCreatedEventMessage.Create(Id.Value);
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
				RecipeInfo recipeInfo,
				IEnumerable<RecipeIngredient> recipeIngredients)
			{
				var recipe =  GetRecipe(id, name, description, recipeInfo, recipeIngredients);
				recipe.Create();
				return recipe;
			}
			
			public Recipe GetRecipe(Guid id, 
				string name, 
				string description,
				RecipeInfo recipeInfo,
				IEnumerable<RecipeIngredient> recipeIngredients)
			{
				var recipeId = new Identity<Guid>(id);
				var recipe =  new Recipe(recipeId, 
					name, 
					description, 
					recipeInfo, 
					recipeIngredients, 
					_eventPublisher, 
					_recipeRepository);
				return recipe;
			}
		}
		
	}
}