using System;
using WhatShouldIEat.Administration.Domain.Recipes.Queries.SearchInfoQueries;

namespace WhatShouldIEat.Administration.Domain.Recipes.Repositories
{
	public interface IRecipeSearchInfoRepository
	{
		void Update(RecipeSearchInfo recipeSearchInfo);
		void Remove(string key);
		void BuildRecipeSearchInfo();
		void UpdateRecipeSearchInfoByIngredientId(Guid id);
	}
}