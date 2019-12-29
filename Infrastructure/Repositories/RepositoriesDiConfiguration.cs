using Domain.Ingredients.Repositories;
using Domain.Recipes.Repositories;
using Infrastructure.Repositories.DataAccess.Ingredients;
using Infrastructure.Repositories.DataAccess.Recipes;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Repositories
{
	public static class RepositoriesDiConfiguration
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddTransient<IIngredientDataReader, IngredientDataReader>()
				.AddTransient<IIngredientDataWriter, IngredientDataWriter>()
				.AddTransient<IRecipeDataReader, RecipeDataReader>()
				.AddTransient<IRecipeDataWriter, RecipeDataWriter>();
				
			services.AddTransient<IIngredientRepository, IngredientRepositoryAdapter>()
				.AddTransient<IRecipeRepository, RecipeRepositoryAdapter>()
				.AddTransient<IRecipeDetailsRepository, RecipeDetailsRepository>();

			return services;
		}
	}
}