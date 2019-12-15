using System;
using Domain.Ingredients.Entities;

namespace Domain.Ingredients.Repositories
{
	public interface IIngredientRepository
	{
		bool ExistByName(string name);
		bool ExistById(Guid id);
		void Add(Ingredient ingredient);
		void Remove(Ingredient ingredient);
		Ingredient? GetById(Guid id);
		void Commit();
	}
}