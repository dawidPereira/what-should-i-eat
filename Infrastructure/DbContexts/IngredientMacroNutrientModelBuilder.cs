using Domain.RecipesDetails.Ingredients.Entities;
using Domain.RecipesDetails.Ingredients.Entities.MacroNutrients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.DbContexts
{
	internal static class IngredientMacroNutrientModelBuilder
	{
		public static ModelBuilder ConfigureIngredientMacroNutrient(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<IngredientMacroNutrient>()
				.HasKey(key => new {key.Id, key.IngredientId});
			
			modelBuilder.Entity<IngredientMacroNutrient>()
				.Property(property => property.MacroNutrient)
				.HasConversion(new EnumToNumberConverter<MacroNutrient,int>());

			modelBuilder.Entity<IngredientMacroNutrient>()
				.HasAlternateKey(key => new {key.Id, key.IngredientId});
			
			return modelBuilder;
		}
	}
}