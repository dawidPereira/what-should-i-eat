using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;

namespace WhatShouldIEat.Administration.Infrastructure.DbContexts
{
	internal static class IngredientMacroNutrientModelBuilder
	{
		public static ModelBuilder ConfigureIngredientMacroNutrient(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<IngredientMacroNutrient>()
				.Property(property => property.MacroNutrient)
				.HasConversion(new EnumToNumberConverter<MacroNutrient,int>());

			modelBuilder.Entity<IngredientMacroNutrient>()
				.HasAlternateKey(key => new {key.Id, key.IngredientId});
			
			return modelBuilder;
		}
	}
}