using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Recipe.Entities.Recipe;

namespace WhatShouldIEat.Administration.Domain.Recipe.Mappers
{
	public interface IRecipeIngredientMapper
	{
		ICollection<RecipeIngredient> MapToListOfRecipeIngredients(
			IEnumerable<Tuple<string, double>> toMap, Id<Entities.Recipe.Recipe> recipeId);

		ICollection<MealType> MapToMealTypes(IEnumerable<int> mealTypes);
	}
}