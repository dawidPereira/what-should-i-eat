using System;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Entities;

namespace Domain.Ingredients.Repositories
{
	public interface IIngredientRepository
	{
		bool ExistById(Guid id);
		bool ExistByName(string name);
		void Add(Ingredient ingredient);
		void Remove(Ingredient ingredient);
		Ingredient? GetById(Identity<Guid> id);
		void Commit();
	}
}