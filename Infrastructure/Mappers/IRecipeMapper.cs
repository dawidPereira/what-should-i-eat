using Domain.Recipes.Entities;

namespace Infrastructure.Mappers
{
	public interface IRecipeMapper
	{
		Recipe ToDomainRecipe(Entities.Recipe.Recipe recipe);
	}
}