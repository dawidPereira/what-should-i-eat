using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Common.Extensions;
using Domain.Common.Mediators.Events;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;
using Domain.RecipesDetails.Recipes.Entities.Ingredients;
using Domain.RecipesDetails.Recipes.Repositories;
using Domain.RecipesDetails.Recipes.SearchInfos;

namespace Domain.RecipesDetails.Recipes.Entities
{
	public class Recipe : IAggregateRoot<Recipe, Guid>
	{
		private readonly IEventPublisher _eventPublisher;
		private readonly IRecipeRepository _recipeRepository;
		public Recipe(Guid id,
			string name,
			string description,
			RecipeDetails recipeDetails,
			IEnumerable<RecipeIngredient> recipeIngredients,
			IEventPublisher eventPublisher,
			IRecipeRepository recipeRepository)
		{
			Id = new Identity<Guid>(id);
			Name = name;
			Description = description;
			RecipeDetails = recipeDetails;
			_eventPublisher = eventPublisher;
			_recipeRepository = recipeRepository;
			RecipeIngredients = new RecipeIngredientsCollection(recipeIngredients);
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
		}

		public RecipeSearchInfo CalculateSearchInfo() =>
			new RecipeSearchInfo(Id,
				GetRequirements(),
				GetAllergens(),
				GetMealTypes(),
				CalculateCalories(),
				GetMacroNutrientQuantity());

		public double CalculateCalories() =>
			RecipeIngredients.Sum(x => x.Ingredient.CalculateCalories(x.Grams));
		
		public MealType GetMealTypes() => RecipeDetails.MealTypes;

		public Allergen GetAllergens() =>
			RecipeIngredients.Select(x => x.Ingredient.Allergens)
				.Aggregate(Allergen.None, (acc, el) => acc | el);

		public Requirement GetRequirements() =>
			RecipeIngredients.Select(x => x.Ingredient.Requirements)
				.Aggregate(Requirement.None, (acc, el) => acc | el);

		public IDictionary<MacroNutrient, double> GetMacroNutrientQuantity() =>
			RecipeIngredients.Select(x => x.Ingredient.GetMacroNutrientQuantity(x.Grams)).MergeDictionary();

		public bool Equals(Recipe other) => !ReferenceEquals(null, other) && Id.Equals(other.Id);

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((Recipe) obj);
		}

		public override int GetHashCode() => Id.GetHashCode();
		
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
		
	}
}