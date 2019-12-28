using Infrastructure.DbContexts.Seeders;
using Infrastructure.Entities.Ingredients;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts
{
	internal static class IngredientModelBuilder
	{
		public static ModelBuilder ConfigureIngredient(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Ingredient>().HasKey(property => property.Id);

			modelBuilder.Entity<Ingredient>()
				.HasMany(x => x.MacroNutrientsShares);
			
			modelBuilder.SeedIngredientData();

			return modelBuilder;
		}
	}
}