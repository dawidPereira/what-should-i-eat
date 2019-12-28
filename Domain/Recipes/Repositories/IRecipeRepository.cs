using System;
using System.Collections.Generic;
using Domain.Recipes.Entities;
using Domain.Recipes.Queries.GetBasicInfos;

namespace Domain.Recipes.Repositories
{
	public interface IRecipeRepository
	{
		Recipe GetById(Guid id);
		IEnumerable<Recipe> GetAll();
		ICollection<RecipeBasicInfo> GetBasicInfos();
		ICollection<RecipeBasicInfo> GetRecipesBasicInfosByIngredientId(Guid ingredientId);
		void Add(Recipe recipe);
		void Update(Recipe recipe);
		void Commit();
		void Remove(Recipe recipe);
		bool ExistByName(string name);
		bool ExistById(Guid id);
	}
}