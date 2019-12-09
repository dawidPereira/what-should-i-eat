using Domain.Ingredients.Entities;
using Infrastructure.DbContexts.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.DbContexts
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
				.HasMany(x => x.MacroNutrientsParticipants);
			
			modelBuilder.SeedIngredientData();

			return modelBuilder;
		}
	}
}