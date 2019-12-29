using Infrastructure.DbContexts;
using Infrastructure.Entities.Ingredients;

namespace Infrastructure.Repositories.DataAccess.Ingredients
{
	public class IngredientDataWriter : IIngredientDataWriter
	{
		private readonly AdministrationDbContext _context;

		public IngredientDataWriter(AdministrationDbContext context)
		{
			_context = context;
		}

		public void Commit() => _context.SaveChanges();

		public void Remove(Ingredient ingredient) => _context.Remove(ingredient);

		public void Add(Ingredient ingredient) => _context.Ingredients.Add(ingredient);

		public void Update(Ingredient ingredient) => _context.Ingredients.Update(ingredient);
	}
}