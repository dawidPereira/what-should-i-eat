using System.Threading.Tasks;
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

		public async Task Commit() => await _context.SaveChangesAsync();

		public async Task Add(Recipe recipe) => await _context.AddAsync(recipe);

		public void Update(Recipe recipe) => _context.Update(recipe);

		public void Remove(Recipe recipe) => _context.Remove(recipe);
	}
}
