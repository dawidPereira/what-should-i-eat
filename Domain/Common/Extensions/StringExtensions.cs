using System;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;
using Domain.Recipes.Entities;

namespace Domain.Common.Extensions
{
	public static class StringExtensions
	{
		public static Requirement ToRequirements(this string source)
		{
			var success = Enum.TryParse<Requirement>( source, true, out var result);
			return success
				? result
				: Requirement.None;
		}
		
		public static Allergen ToAllergens(this string source)
		{
			var success = Enum.TryParse<Allergen>( source, true, out var result);
			return success
				? result
				: Allergen.None;
		}
		
		public static MacroNutrient ToMacroNutrient(this string source)
		{
			var success = Enum.TryParse<MacroNutrient>( source, true, out var result);
			return success
				? result
				: throw new ArgumentException($"Not existed macro nutrient: {source}");
		}
		
		public static MealType ToMealType(this string source)
		{
			var success = Enum.TryParse<MealType>( source, true, out var result);
			return success
				? result
				: throw new ArgumentException($"Not existed macro nutrient: {source}");
		}
	}
}