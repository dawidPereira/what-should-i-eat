using Infrastructure.Entities.Recipe;

namespace Infrastructure.Repositories.DataAccess.Recipes
{
	public interface IRecipeDataWriter
	{
		void Commit();
		
		void Add(Recipe recipe);
		
		void Update(Recipe recipe);
		
		void Remove(Recipe recipe);
	}
}