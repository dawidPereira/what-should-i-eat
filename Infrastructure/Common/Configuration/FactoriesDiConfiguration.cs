using Domain.Common.Filters;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Factories;
using Domain.Recipes.Entities;
using Domain.Recipes.Factories;
using Domain.RecipesDetails.Entities;
using Domain.RecipesDetails.Filters.Factories;
using Domain.RecipesDetails.Filters.FiltersCriteria;
using Domain.RecipesDetails.RecipeDetailsFactories;
using Microsoft.Extensions.DependencyInjection;
using Recipe = Domain.Recipes.Entities.Recipe;

namespace Infrastructure.Common.Configuration
{
	public static class FactoriesDiConfiguration
	{
		public static IServiceCollection AddFactories(this IServiceCollection services)
		{
			services.AddTransient<IRecipeFactory, Recipe.RecipeFactory>()
				.AddTransient<IRecipeDetailsFactory, RecipeDetailsFactory>()
				.AddTransient<IIngredientFactory, Ingredient.IngredientFactory>()
				.AddTransient<IRecipeIngredientFactory, RecipeIngredient.RecipeIngredientFactory>()
				.AddTransient<IFilterFactory<RecipeDetails, RecipeSearchFilterCriteria>, RecipeFiltersFactory>();
			return services;
		}
	}
}