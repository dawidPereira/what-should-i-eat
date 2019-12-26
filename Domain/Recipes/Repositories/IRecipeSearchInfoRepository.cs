using System.Collections.Generic;
using Domain.RecipesDetails.Entities;
using Domain.RecipesDetails.SearchInfos;

namespace Domain.Recipes.Repositories
{
	public interface IRecipeSearchInfoRepository
	{
		void Add(RecipeDetails recipeDetails);
		void Remove(string key);
		void AddRange(IEnumerable<RecipeDetails> recipeSearchInfos);
	}
}