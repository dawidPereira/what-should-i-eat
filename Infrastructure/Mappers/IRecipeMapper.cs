using Domain.Recipes.Entities;
using Domain.Recipes.Repositories;

namespace Infrastructure.Mappers
{
	public interface IRecipeMapper
	{
		Recipe ToDomainRecipe(Entities.Recipe.Recipe recipe, IRecipeRepository recipeRepository);
	}
}