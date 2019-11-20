using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Dto.IngredientsDto;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Repositories
{
	public interface IIngredientRepository
	{
		void Add(Ingredient ingredient);
		void Remove(Ingredient ingredient);
		void Update(Ingredient ingredient);
		
		bool ExistByName(string name);
		bool ExistById(Id<Ingredient> id);
		Ingredient GetById(Id<Ingredient> id);
		ICollection<IngredientBasicInfo> GetIngredientBasicInfos();
		ICollection<IngredientBasicInfo> GetAllBasicInfos();
		
		void Commit();
	}
}