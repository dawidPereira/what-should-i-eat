using System;
using System.Collections.Generic;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Entities;

namespace Domain.Ingredients.Repositories
{
	public interface IIngredientRepository
	{
		bool ExistById(Identity<Guid> id);
		bool ExistByName(string name);
		void Add(Ingredient ingredient);
		void Remove(Ingredient ingredient);
		Ingredient? GetById(Identity<Guid> id);
		IEnumerable<Ingredient> GetByIds(ICollection<Identity<Guid>> ids);
		void Commit();
	}
}