using System;
using System.Collections.Generic;
using Domain.Ingredients.Entities;

namespace Domain.Ingredients.Repositories
{
	public interface IIngredientRepository
	{
		bool ExistByName(string name);
		bool ExistById(Guid id);
		void Add(Ingredient ingredient);
		void Update(Ingredient ingredient);
		void Remove(Ingredient ingredient);
		Ingredient? GetById(Guid id);
		ICollection<Ingredient> GetByIds(ICollection<Guid> ids);
		void Commit();
	}
}