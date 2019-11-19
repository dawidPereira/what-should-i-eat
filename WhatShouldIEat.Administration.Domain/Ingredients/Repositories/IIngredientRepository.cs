using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Repositories
{
	public interface IIngredientRepository
	{
		bool ExistByName(string name);
		void Add(Ingredient ingredient);
		void Update(Ingredient ingredient);
		Ingredient? GetById(Id<Ingredient> id);
		void Commit();
	}
}