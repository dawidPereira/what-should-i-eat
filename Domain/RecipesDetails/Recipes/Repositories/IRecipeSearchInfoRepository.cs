using System.Collections.Generic;
using Domain.RecipesDetails.Recipes.SearchInfos;

namespace Domain.RecipesDetails.Recipes.Repositories
{
	public interface IRecipeSearchInfoRepository
	{
		void Add(RecipeSearchInfo recipeSearchInfo);
		void Remove(string key);
		void AddRange(IEnumerable<RecipeSearchInfo> recipeSearchInfos);
	}
}