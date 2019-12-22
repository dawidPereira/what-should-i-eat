using System;
using System.Collections.Generic;
using Domain.Common.ValueObjects;
using Domain.Recipes.Entities;
using Domain.Recipes.Queries.GetBasicInfos;

namespace Domain.Recipes.Repositories
{
	public interface IRecipeRepository
	{
		Recipe GetById(Guid id);
		IEnumerable<Recipe> GetAll();
		IEnumerable<Recipe> GetRecipesByIngredientId(Guid id);
		ICollection<RecipeBasicInfo> GetBasicInfos();
		ICollection<RecipeBasicInfo> GetRecipesBasicInfosByIngredientId(Identity<Guid> ingredientId);
		void Add(Recipe recipe);
		void Commit();
		void Delete(Recipe recipe);
		bool ExistByName(string name);
		bool ExistById(Guid id);
	}
}