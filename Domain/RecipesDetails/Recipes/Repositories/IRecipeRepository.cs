using System;
using System.Collections.Generic;
using Domain.RecipesDetails.Recipes.Entities;
using Domain.RecipesDetails.Recipes.Queries.GetBasicInfos;

namespace Domain.RecipesDetails.Recipes.Repositories
{
	public interface IRecipeRepository
	{
		Recipe GetById(Guid id);
		IEnumerable<Recipe> GetAll();
		IEnumerable<Recipe> GetRecipesByIngredientId(Guid id);
		ICollection<RecipeBasicInfo> GetBasicInfos();
		ICollection<RecipeBasicInfo> GetRecipesBasicInfosByIngredientId(Guid ingredientId);
		void Add(Recipe recipe);
		void Commit();
		void Delete(Recipe recipe);
		bool ExistByName(string name);
		bool ExistById(Guid id);
	}
}