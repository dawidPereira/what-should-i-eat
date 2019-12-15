using System;
using System.Collections.Generic;
using Domain.RecipesDetails.Ingredients.Entities;
using Domain.RecipesDetails.Ingredients.Queries.GetIngredientsBasicInfos;

namespace Domain.RecipesDetails.Ingredients.Repositories
{
	public interface IIngredientRepository
	{
		void Add(Ingredient ingredient);
		void Remove(Ingredient ingredient);
		bool ExistByName(string name);
		bool ExistById(Guid id);
		Ingredient GetById(Guid id);
		ICollection<IngredientBasicInfo> GetBasicInfos();
		void Commit();
	}
}