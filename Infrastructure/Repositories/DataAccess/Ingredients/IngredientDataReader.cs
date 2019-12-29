using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.DbContexts;
using Infrastructure.Entities.Ingredients;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.DataAccess.Ingredients
{
	public class IngredientDataReader : IIngredientDataReader
	{
		private readonly AdministrationDbContext _context;

		public IngredientDataReader(AdministrationDbContext context)
		{
			_context = context;
		}
		
		public bool ExistByName(string name) => _context.Ingredients.Any(x => x.Name == name);

		public bool ExistById(Guid id) => _context.Ingredients.Any(x => x.Id == id);
		
		public Ingredient GetById(Guid id) => _context.Ingredients
			.Include(x => x.MacroNutrientsShares)
			.FirstOrDefault(x => x.Id == id);

		public IEnumerable<Ingredient> GetByIds(ICollection<Guid> ids) => _context.Ingredients
			.Include(x => x.MacroNutrientsShares)
			.Where(x => ids.Contains(x.Id));
	}
}