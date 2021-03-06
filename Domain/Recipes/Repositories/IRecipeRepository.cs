﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Recipes.Entities;
using Domain.Recipes.Queries.GetBasicInfos;

namespace Domain.Recipes.Repositories
{
	public interface IRecipeRepository
	{
		Recipe GetById(Guid id);

		IEnumerable<Guid> GetAllIds();

		IDictionary<Guid, double> GetRecipeIngredientsById(Guid id);

		ICollection<RecipeBasicInfo> GetBasicInfos();

		ICollection<RecipeBasicInfo> GetRecipesBasicInfosByIngredientId(Guid ingredientId);

		Task Add(Recipe recipe);

		void Update(Recipe recipe);

		Task Commit();

		void Remove(Recipe recipe);

		bool ExistByName(string name);

		bool ExistById(Guid id);
	}
}
