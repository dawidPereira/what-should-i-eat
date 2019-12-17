using System;
using Domain.Ingredients.Entities;

namespace Domain.Ingredients.Repositories
{
	public interface IIngredientRepository
	{
		bool ExistById(Guid id);
		bool ExistByName(string name);
		void Add(Ingredient ingredient);
		void Remove(Ingredient ingredient);
		Ingredient? GetById(Guid id);
		void Commit();
	}
}