using Domain.Events.Repositories;
using Domain.Ingredients.Repositories;
using Domain.Recipes.Repositories;
using Domain.RecipesDetails.Repositories;
using Infrastructure.Repositories.DataAccess.Events;
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
				.AddTransient<IRecipeDataWriter, RecipeDataWriter>()
				.AddTransient<IEventDataReader, EventDataReader>()
				.AddTransient<IEventDataWriter, EventDataWriter>();

			services.AddTransient<IIngredientRepository, IngredientRepositoryAdapter>()
				.AddTransient<IRecipeRepository, RecipeRepositoryAdapter>()
				.AddTransient<IEventRepository, EventRepository>()
				.AddTransient<IRecipeDetailsRepository, RecipeDetailsRepository>();

			return services;
		}
	}
}