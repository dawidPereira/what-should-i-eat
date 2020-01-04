using System;
using System.Collections.Generic;
using Infrastructure.Entities.Ingredient;
using Infrastructure.Entities.Ingredients;
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
				new MacroNutrientShares(temporaryIngredientId, "Carbohydrate", 0.2),
				new MacroNutrientShares(temporaryIngredientId, "Fat", 0.1),
				new MacroNutrientShares(temporaryIngredientId, "Protein", 0.6)
			};
			modelBuilder.Entity<Ingredient>(property =>
			{
				property.HasData(new Ingredient(
					temporaryIngredientId,
					"Chicken",
					"None",
					"ForVegan",
					new List<MacroNutrientShares>()));
			});

			modelBuilder.Entity<MacroNutrientShares>(property => { property.HasData(macroNutrientShares); });

			temporaryIngredientId = new Guid(SeedConst.Rice);
			macroNutrientShares = new List<MacroNutrientShares>
			{
				new MacroNutrientShares(temporaryIngredientId, "Carbohydrate", 0.8),
				new MacroNutrientShares(temporaryIngredientId, "Fat", 0.0),
				new MacroNutrientShares(temporaryIngredientId, "Protein", 0.2)
			};
			
			modelBuilder.Entity<Ingredient>(property =>
			{
				property.HasData(new Ingredient(
					temporaryIngredientId,
					"Rice",
					"None",
					"ForVegan",
					new List<MacroNutrientShares>()));
			});
			
			modelBuilder.Entity<MacroNutrientShares>(property => { property.HasData(macroNutrientShares); });

			temporaryIngredientId = new Guid(SeedConst.Oatmeal);
			macroNutrientShares = new List<MacroNutrientShares>
			{
				new MacroNutrientShares(temporaryIngredientId, "Carbohydrate", 0.7),
				new MacroNutrientShares(temporaryIngredientId, "Fat", 0.1),
				new MacroNutrientShares(temporaryIngredientId, "Protein", 0.2)
			};
			
			modelBuilder.Entity<Ingredient>(property =>
			{
				property.HasData(new Ingredient(
					temporaryIngredientId,
					"Oatmeal",
					"Gluten",
					"ForVegan",
					new List<MacroNutrientShares>()));
			});
			
			modelBuilder.Entity<MacroNutrientShares>(property => { property.HasData(macroNutrientShares); });
			
			temporaryIngredientId = new Guid(SeedConst.Milk);
			macroNutrientShares = new List<MacroNutrientShares>
			{
				new MacroNutrientShares(temporaryIngredientId, "Carbohydrate", 0.2),
				new MacroNutrientShares(temporaryIngredientId, "Fat", 0.1),
				new MacroNutrientShares(temporaryIngredientId, "Protein", 0.2)
			};
			
			modelBuilder.Entity<Ingredient>(property =>
			{
				property.HasData(new Ingredient(
					temporaryIngredientId,
					"Milk",
					"Gluten",
					"ForVegan",
					new List<MacroNutrientShares>()));
			});
			
			modelBuilder.Entity<MacroNutrientShares>(property => { property.HasData(macroNutrientShares); });

			return modelBuilder;
		}
	}
}