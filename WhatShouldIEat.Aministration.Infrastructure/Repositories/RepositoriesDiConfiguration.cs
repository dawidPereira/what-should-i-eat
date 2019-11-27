using Microsoft.Extensions.DependencyInjection;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Aministration.Infrastructure.Repositories
{
	public static  class RepositoriesDiConfiguration
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddTransient<IRecipeRepository, RecipeRepository>()
				.AddTransient<IIngredientRepository, IngredientRepository>();

			return services;
		}
	}
}