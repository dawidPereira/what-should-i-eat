using System;
using System.Collections.Generic;
using System.Linq;
using WhatShouldIEat.Administration.Domain.Common;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.Administration.Domain.Recipe.Entities.Recipe;

namespace WhatShouldIEat.Administration.Domain.Recipe.Mappers
{
	using Recipe = Entities.Recipe.Recipe;
	
	public class RecipeIngredientMapper : IRecipeIngredientMapper
	{
		private readonly IIngredientRepository _ingredientRepository;

		public RecipeIngredientMapper(IIngredientRepository ingredientRepository) =>
			_ingredientRepository = ingredientRepository;

		public ICollection<RecipeIngredient> MapToListOfRecipeIngredients(
			IEnumerable<Tuple<string, double>> toMap, Id<Recipe> recipeId) => toMap
			.Select(x => MapToRecipeIngredient(x.Item1, x.Item2, recipeId))
			.ToList();

		private RecipeIngredient MapToRecipeIngredient(string ingredientId, double grams, Id<Recipe> recipeId)
		{
			ThrowExceptionIfIngredientDoesNotExist(ingredientId);
			return new RecipeIngredient(new Id<Ingredient>(new Guid(ingredientId)), recipeId, grams);
		}

		private void ThrowExceptionIfIngredientDoesNotExist(string ingredientId)
		{
			var id = new Id<Ingredient>(new Guid(ingredientId));
			if (!_ingredientRepository.ExistById(id))
				Exceptions<Ingredient>.ThrowNotFoundException(nameof(Ingredient), ingredientId);
		}

		public ICollection<MealType> MapToMealTypes(IEnumerable<int> mealTypes) =>
			mealTypes.Select(x => (MealType) x).ToList();
	}
}