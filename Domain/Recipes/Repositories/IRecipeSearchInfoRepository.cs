using System;
using Domain.Recipes.Queries.SearchInfoQueries;

namespace Domain.Recipes.Repositories
{
	public interface IRecipeSearchInfoRepository
	{
		void Update(RecipeSearchInfo recipeSearchInfo);
		void Remove(string key);
		void BuildRecipeSearchInfo();
		void UpdateRecipeSearchInfoByIngredientId(Guid id);
	}
}