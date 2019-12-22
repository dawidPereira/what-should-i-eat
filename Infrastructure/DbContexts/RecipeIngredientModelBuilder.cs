using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts
{
	internal static class RecipeIngredientModelBuilder
	{
		public static ModelBuilder ConfigureRecipeIngredient(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<RecipeIngredient>()
				.HasKey(recipeIngredient => new { recipeIngredient.IngredientId, recipeIngredient.RecipeId });  
			
			modelBuilder.Entity<RecipeIngredient>()
				.HasOne(property => property.Ingredient)
				.WithMany(property => property.RecipeIngredients);

			modelBuilder.Entity<RecipeIngredient>()
				.HasOne(property => property.Recipe)
				.WithMany(property => property.RecipeIngredients);

			return modelBuilder;
		}
	}
}