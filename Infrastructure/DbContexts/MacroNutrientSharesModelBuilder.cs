using Infrastructure.Entities.Ingredient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts
{
	internal static class MacroNutrientSharesModelBuilder
	{
		public static ModelBuilder ConfigureIngredientMacroNutrient(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MacroNutrientShares>()
				.HasKey(key => new {key.MacroNutrient, key.IngredientId});
			
			return modelBuilder;
		}
	}
}