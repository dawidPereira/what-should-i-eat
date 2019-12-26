using System.Collections.Generic;
using Domain.RecipesDetails.Entities;

namespace Domain.Recipes.Repositories
{
	public interface IRecipeDetailsRepository
	{
		void Add(RecipeDetails recipeDetails);
		void Remove(string key);
		void AddRange(IEnumerable<RecipeDetails> recipeSearchInfos);
	}
}