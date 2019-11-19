using WhatShouldIEat.Administration.Domain.Ingredients.Entities;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Repositories
{
	public interface IIngredientRepository
	{
		bool ExistByName(string name);

		void Add(Ingredient ingredient);

		void Commit();
	}
}