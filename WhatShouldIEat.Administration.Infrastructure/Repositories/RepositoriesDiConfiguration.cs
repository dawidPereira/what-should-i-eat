using Microsoft.Extensions.DependencyInjection;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Infrastructure.Repositories
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