using Microsoft.EntityFrameworkCore;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;

namespace WhatShouldIEat.Administration.Infrastructure.DbContexts
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