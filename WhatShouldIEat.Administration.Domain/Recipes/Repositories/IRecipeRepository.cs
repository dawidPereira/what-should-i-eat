using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Recipes.Dtos;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;

namespace WhatShouldIEat.Administration.Domain.Recipes.Repositories
{
	public interface IRecipeRepository
	{
		Recipe GetById(Guid id);
		ICollection<RecipeBasicInfo> GetBasicInfos();
		ICollection<RecipeBasicInfo> GetRecipesBasicInfosByIngredientId(Guid ingredientId);
		void Add(Recipe recipe);
		void Update(Recipe recipe);
		void Commit();
		void Delete(Recipe recipe);
		bool ExistByName(string name);
		bool ExistById(Guid id);
	}
}