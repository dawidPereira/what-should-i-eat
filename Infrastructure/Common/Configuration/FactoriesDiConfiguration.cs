using Domain.Ingredients.Entities;
using Domain.Ingredients.Factories;
using Domain.Recipes.Entities;
using Domain.Recipes.Factories;
using Domain.RecipesDetails.RecipeDetailsFactories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Common.Configuration
{
	public static class FactoriesDiConfiguration
	{
		public static IServiceCollection AddFactories(this IServiceCollection services)
		{
			services.AddTransient<IRecipeFactory, Recipe.RecipeFactory>();
			services.AddTransient<IRecipeDetailsFactory, RecipeDetailsFactory>();
			services.AddTransient<IIngredientFactory, Ingredient.IngredientFactory>();
			services.AddTransient<IRecipeIngredientFactory, RecipeIngredient.RecipeIngredientFactory>();
			return services;
		}
	}
}