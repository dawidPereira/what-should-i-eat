using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;

namespace WhatShouldIEat.Administration.Infrastructure.DbContexts
{
	internal static class IngredientModelBuilder
	{
		public static ModelBuilder ConfigureIngredient(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Ingredient>().HasKey(property => property.Id);

			modelBuilder.Entity<Ingredient>()
				.Property(property => property.Allergens)
				.HasConversion(new EnumToNumberConverter<Allergen,int>());
			
			modelBuilder.Entity<Ingredient>()
				.Property(property => property.Requirements)
				.HasConversion(new EnumToNumberConverter<Requirement,int>());
			
			modelBuilder.Entity<Ingredient>()
				.HasMany(property => property.MacroNutrientsParticipants)
				.WithOne(property => property.Ingredient);
			
			return modelBuilder;
		}
	}
}