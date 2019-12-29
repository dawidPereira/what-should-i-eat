using Infrastructure.Entities.Recipe;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts
{
	internal static class RecipeIngredientModelBuilder
	{
		public static ModelBuilder ConfigureRecipeIngredient(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<RecipeIngredient>()
				.HasKey(recipeIngredient => new { recipeIngredient.RecipeId, recipeIngredient.IngredientId });  
			
			return modelBuilder;
		}
	}
}