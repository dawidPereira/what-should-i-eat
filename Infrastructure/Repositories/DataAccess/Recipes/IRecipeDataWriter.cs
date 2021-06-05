using System.Threading.Tasks;
using Infrastructure.Entities.Recipe;

namespace Infrastructure.Repositories.DataAccess.Recipes
{
	public interface IRecipeDataWriter
	{
		Task Commit();

		Task Add(Recipe recipe);

		void Update(Recipe recipe);

		void Remove(Recipe recipe);
	}
}
