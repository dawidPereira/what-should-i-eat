using System;
using System.Collections.Generic;
using Infrastructure.Entities.Ingredient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts.Seeders
{
	public static class IngredientSeeder
	{
		public static ModelBuilder SeedIngredientData(this ModelBuilder modelBuilder)
		{
			var temporaryIngredientId = new Guid(SeedConst.Chicken);

			var macroNutrientShares = new List<MacroNutrientShares>
			{
				new MacroNutrientShares(temporaryIngredientId, 1, 0.2),
				new MacroNutrientShares(temporaryIngredientId, 2, 0.1),
				new MacroNutrientShares(temporaryIngredientId, 4, 0.6)
			};
			modelBuilder.Entity<Ingredient>(property =>
			{
				property.HasData(new Ingredient(
					temporaryIngredientId,
					"Chicken",
					0,
					4,
					macroNutrientShares));
			});

			temporaryIngredientId = new Guid(SeedConst.Rice);
			macroNutrientShares = new List<MacroNutrientShares>
			{
				new MacroNutrientShares(temporaryIngredientId, 1, 0.8),
				new MacroNutrientShares(temporaryIngredientId, 2, 0.0),
				new MacroNutrientShares(temporaryIngredientId, 4, 0.2)
			};
			modelBuilder.Entity<Ingredient>(property =>
			{
				property.HasData(new Ingredient(
					temporaryIngredientId,
					"Rice",
					0,
					7,
					macroNutrientShares));
			});

			temporaryIngredientId = new Guid(SeedConst.Oatmeal);
			macroNutrientShares = new List<MacroNutrientShares>
			{
				new MacroNutrientShares(temporaryIngredientId, 1, 0.7),
				new MacroNutrientShares(temporaryIngredientId, 2, 0.1),
				new MacroNutrientShares(temporaryIngredientId, 4, 0.2)
			};
			modelBuilder.Entity<Ingredient>(property =>
			{
				property.HasData(new Ingredient(
					temporaryIngredientId,
					"Oatmeal",
					1,
					7,
					macroNutrientShares));
			});
			
			temporaryIngredientId = new Guid(SeedConst.Milk);
			macroNutrientShares = new List<MacroNutrientShares>
			{
				new MacroNutrientShares(temporaryIngredientId, 1, 0.2),
				new MacroNutrientShares(temporaryIngredientId, 2, 0.1),
				new MacroNutrientShares(temporaryIngredientId, 4, 0.2)
			};
			modelBuilder.Entity<Ingredient>(property =>
			{
				property.HasData(new Ingredient(
					temporaryIngredientId,
					"Milk",
					1,
					7,
					macroNutrientShares));
			});
			
			return modelBuilder;
		}
	}
}