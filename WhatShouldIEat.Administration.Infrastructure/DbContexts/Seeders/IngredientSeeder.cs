using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;

namespace WhatShouldIEat.Administration.Infrastructure.DbContexts.Seeders
{
	public static class IngredientSeeder
	{
		public static ModelBuilder SeedIngredientData(this ModelBuilder modelBuilder)
		{
			var temporaryIngredientId = new Guid(SeedConst.Chicken);

			modelBuilder.Entity<Ingredient>(property =>
			{
				property.HasData(Ingredient.Create(
					temporaryIngredientId,
					"Chicken",
					Allergen.None,
					Requirement.Ecological,
					new List<IngredientMacroNutrient>()));
			});

			modelBuilder.Entity<IngredientMacroNutrient>(property =>
			{
				property.HasData(new List<IngredientMacroNutrient>
				{
					new IngredientMacroNutrient(temporaryIngredientId, MacroNutrient.Carbohydrate, 0.2),
					new IngredientMacroNutrient(temporaryIngredientId, MacroNutrient.Fat, 0.1),
					new IngredientMacroNutrient(temporaryIngredientId, MacroNutrient.Protein, 0.6)
				});
			});


			temporaryIngredientId = new Guid(SeedConst.Rice);
			modelBuilder.Entity<Ingredient>(property =>
			{
				property.HasData(Ingredient.Create(
					temporaryIngredientId,
					"Rice",
					Allergen.None,
					Requirement.Ecological | Requirement.ForVegan | Requirement.ForVegetarian,
					new List<IngredientMacroNutrient>()));
			});
			modelBuilder.Entity<IngredientMacroNutrient>(property =>
			{
				property.HasData(new List<IngredientMacroNutrient>
				{
					new IngredientMacroNutrient(temporaryIngredientId, MacroNutrient.Carbohydrate, 0.8),
					new IngredientMacroNutrient(temporaryIngredientId, MacroNutrient.Fat, 0),
					new IngredientMacroNutrient(temporaryIngredientId, MacroNutrient.Protein, 0.2)
				});
			});

			temporaryIngredientId = new Guid(SeedConst.Oatmeal);
			modelBuilder.Entity<Ingredient>(property =>
			{
				property.HasData(Ingredient.Create(
					temporaryIngredientId,
					"Oatmeal",
					Allergen.Gluten,
					Requirement.ForVegan | Requirement.Ecological | Requirement.ForVegetarian,
					new List<IngredientMacroNutrient>()));
			});
			modelBuilder.Entity<IngredientMacroNutrient>(property =>
			{
				property.HasData(new List<IngredientMacroNutrient>
				{
					new IngredientMacroNutrient(temporaryIngredientId, MacroNutrient.Carbohydrate, 0.7),
					new IngredientMacroNutrient(temporaryIngredientId, MacroNutrient.Fat, 0.1),
					new IngredientMacroNutrient(temporaryIngredientId, MacroNutrient.Protein, 0.2)
				});
			});

			temporaryIngredientId = new Guid(SeedConst.Milk);
			modelBuilder.Entity<Ingredient>(property =>
			{
				property.HasData(Ingredient.Create(
					temporaryIngredientId,
					"Milk",
					Allergen.Gluten,
					Requirement.ForVegan | Requirement.Ecological | Requirement.ForVegetarian,
					new List<IngredientMacroNutrient>()));
			});
			modelBuilder.Entity<IngredientMacroNutrient>(property =>
			{
				property.HasData(new List<IngredientMacroNutrient>
				{
					new IngredientMacroNutrient(temporaryIngredientId, MacroNutrient.Carbohydrate, 0.2),
					new IngredientMacroNutrient(temporaryIngredientId, MacroNutrient.Fat, 0.1),
					new IngredientMacroNutrient(temporaryIngredientId, MacroNutrient.Protein, 0.2)
				});
			});

			return modelBuilder;
		}
	}
}