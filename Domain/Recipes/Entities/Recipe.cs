using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Common.Extensions;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;
using Domain.Recipes.Commands.Update;
using Domain.Recipes.Queries.GetRecipe;
using Domain.Recipes.Queries.SearchInfoQueries;

namespace Domain.Recipes.Entities
{
	public class Recipe
	{
		private Recipe()
		{
		}

		private Recipe(Guid id,
			string name,
			string description,
			RecipeDetails recipeDetails,
			ICollection<RecipeIngredient> recipeIngredients)
		{
			Id = id;
			Name = name;
			Description = description;
			RecipeDetails = recipeDetails;
			RecipeIngredients = recipeIngredients;
		}

		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public RecipeDetails RecipeDetails { get; private set; }
		public ICollection<RecipeIngredient> RecipeIngredients { get; private set; }

		public static Recipe Create(
			Guid id,
			string name,
			string description,
			RecipeDetails recipeDetails,
			ICollection<RecipeIngredient> recipeIngredients) =>
			new Recipe(id, name, description, recipeDetails, recipeIngredients);

		public void Update(UpdateRecipeCommand command)
		{
			Id = command.Id;
			Name = command.Name;
			Description = command.Description;
			RecipeDetails = command.RecipeDetails;
			RecipeIngredients = command.RecipeIngredients;
		}

		public RecipeDto ToDto() => new RecipeDto
		{
			Id = Id,
			Name = Name,
			Description = Description,
			RecipeDetails = RecipeDetails,
			RecipeIngredients = RecipeIngredients
		};

		public RecipeSearchInfo CalculateSearchInfo() =>
			new RecipeSearchInfo(Id,
				GetRequirements(), 
				GetAllergens(),
				GetMealTypes(),
				CalculateCalories(),
				GetMacroNutrientQuantity());

		private double CalculateCalories() =>
			RecipeIngredients.Sum(x => x.Ingredient.CalculateCalories(x.Grams));

		private MealType GetMealTypes() => RecipeDetails.MealTypes;

		private Allergen GetAllergens() =>
			RecipeIngredients.Select(x => x.Ingredient.Allergens)
				.Aggregate(Allergen.None, (acc, el) => acc | el);

		private Requirement GetRequirements() =>
			RecipeIngredients.Select(x => x.Ingredient.Requirements)
				.Aggregate(Requirement.None, (acc, el) => acc | el);

		private IDictionary<MacroNutrient, double> GetMacroNutrientQuantity() =>
			RecipeIngredients.Select(x => x.Ingredient.GetMacroNutrientQuantity(x.Grams))
				.MergeDictionary();
	}
}