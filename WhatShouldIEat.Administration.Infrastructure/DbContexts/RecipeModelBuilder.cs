using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;

namespace WhatShouldIEat.Administration.Infrastructure.DbContexts
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

			return modelBuilder;
		}
	}
}