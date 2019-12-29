using System;
using System.Collections.Generic;
using Domain.Recipes.Queries.GetBasicInfos;
using Infrastructure.Entities.Recipe;

namespace Infrastructure.Repositories.DataAccess.Recipes
{
	public interface IRecipeDataReader
	{
		bool ExistById(Guid id);
		
		bool ExistByName(string name);
		
		IEnumerable<Recipe> GetAll();
		
		Recipe GetById(Guid id);
		
		IEnumerable<RecipeBasicInfo> GetBasicInfos();

		IEnumerable<RecipeBasicInfo> GetRecipesBasicInfosByIngredientId(Guid ingredientId);
	}
}