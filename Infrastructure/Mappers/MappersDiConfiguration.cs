using Infrastructure.Mappers.Events;
using Infrastructure.Mappers.Ingredients;
using Infrastructure.Mappers.Recipes;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Mappers
{
	public static class MappersDiConfiguration
	{
		public static IServiceCollection AddMappers(this IServiceCollection services)
		{
			services.AddTransient<IIngredientMapper, IngredientMapper>()
				.AddTransient<IRecipeMapper, RecipeMapper>()
				.AddTransient<IEventMapper, EventMapper>()
				.AddTransient<IRecipeDetailsMapper, RecipeDetailsMapper>();

			return services;
		}
	}
}