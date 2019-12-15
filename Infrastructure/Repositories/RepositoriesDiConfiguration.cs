using Domain.RecipesDetails.Ingredients.Repositories;
using Domain.RecipesDetails.Recipes.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Repositories
{
	public static class RepositoriesDiConfiguration
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddTransient<IIngredientRepository, IngredientRepository>()
				.AddTransient<IRecipeRepository, RecipeRepository>();

			return services;
		}
	}
}