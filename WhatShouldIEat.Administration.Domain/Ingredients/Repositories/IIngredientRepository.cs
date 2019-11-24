using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Queries.GetIngredientsBasicInfosQuery;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Repositories
{
	public interface IIngredientRepository
	{
		void Add(Ingredient ingredient);
		void Remove(Ingredient ingredient);
		void Update(Ingredient ingredient);
		
		bool ExistByName(string name);
		bool ExistById(Guid id);
		Ingredient GetById(Guid id);
		ICollection<IngredientBasicInfo> GetIngredientBasicInfos();
		ICollection<IngredientBasicInfo> GetAllBasicInfos();
		
		void Commit();
	}
}