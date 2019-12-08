using System;
using WhatShouldIEat.Administration.Domain.Recipes.Queries.SearchInfoQueries;

namespace WhatShouldIEat.Administration.Api.Cache
{
	public interface IRecipeSearchInfoCacheInvalidator
	{
		void Update(RecipeSearchInfo recipeSearchInfo);
		void Remove(string key);
		void BuildRecipeSearchInfo();
		void UpdateRecipeSearchInfoByIngredientId(Guid id);
	}
}