using System;
using System.Collections.Generic;
using Infrastructure.Entities.Ingredients;

namespace Infrastructure.Repositories.DataAccess.Ingredients
{
	public interface IIngredientDataReader
	{
		bool ExistByName(string name);
		
		bool ExistById(Guid id);
		
		Ingredient GetById(Guid id);
		
		IEnumerable<Ingredient> GetByIds(ICollection<Guid> ids);
	}
}