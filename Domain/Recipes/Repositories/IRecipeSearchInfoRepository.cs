using System.Collections.Generic;
using Domain.Recipes.SearchInfos;

namespace Domain.Recipes.Repositories
{
	public interface IRecipeSearchInfoRepository
	{
		void Add(RecipeSearchInfo recipeSearchInfo);
		void Remove(string key);
		void AddRange(IEnumerable<RecipeSearchInfo> recipeSearchInfos);
	}
}