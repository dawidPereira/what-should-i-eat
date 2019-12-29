using Infrastructure.DbContexts;
using Infrastructure.Entities.Recipe;

namespace Infrastructure.Repositories.DataAccess.Recipes
{
	public class RecipeDataWriter : IRecipeDataWriter
	{
		private readonly AdministrationDbContext _context;

		public RecipeDataWriter(AdministrationDbContext context)
		{
			_context = context;
		}

		public void Commit() => _context.SaveChanges();

		public void Add(Recipe recipe) => _context.Add(recipe);

		public void Update(Recipe recipe) => _context.Update(recipe);

		public void Remove(Recipe recipe) => _context.Remove(recipe);
	}
}