using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Repositories
{
	public interface IIngredientRepository
	{
		bool ExistByName(string name);
		bool ExistById(Id<Ingredient> id);
		void Add(Ingredient ingredient);
		void Remove(Ingredient ingredient);
		void Update(Ingredient ingredient);
		Ingredient? GetById(Id<Ingredient> id);
		void Commit();
	}
}