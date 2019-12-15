using Domain.RecipesDetails.Recipes.Entities;
using Infrastructure.DbContexts.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.DbContexts
{
	internal static class RecipeModelBuilder
	{
		public static ModelBuilder ConfigureRecipe(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Recipe>()
				.OwnsOne(property => property.RecipeDetails,
					recipeDetails =>
					{
						recipeDetails
							.Property(property => property.MealTypes)
							.HasConversion(new EnumToNumberConverter<MealType, int>());
					});

			modelBuilder.SeedRecipeData();

			return modelBuilder;
		}
	}
}