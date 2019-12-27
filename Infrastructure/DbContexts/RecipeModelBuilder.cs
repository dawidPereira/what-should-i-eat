using Domain.Recipes.Entities;
using Infrastructure.DbContexts.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Recipe = Infrastructure.Entities.Recipe.Recipe;

namespace Infrastructure.DbContexts
{
	internal static class RecipeModelBuilder
	{
		public static ModelBuilder ConfigureRecipe(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Recipe>()
				.OwnsOne(property => property.RecipeInfo,
					recipeInfo =>
					{
						recipeInfo
							.Property(property => property.MealTypes)
							.HasConversion(new EnumToNumberConverter<MealType, int>());
					});
			modelBuilder.Entity<Recipe>()
				.HasMany(property => property.RecipeIngredients);

			modelBuilder.SeedRecipeData();

			return modelBuilder;
		}
	}
}