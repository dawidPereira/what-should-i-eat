using System.Collections.Generic;
using System.Linq;
using Domain.Common.Extensions;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;

namespace Domain.RecipesDetails.Entities
{
	public struct AggregatedIngredientsDetails : IValueObject<AggregatedIngredientsDetails>
	{
		public AggregatedIngredientsDetails(double calories,
			string allergens,
			string requirements,
			IDictionary<string, double> macroNutrientQuantity)
		{
			Calories = calories;
			Allergens = allergens.ToAllergens();
			Requirements = requirements.ToRequirements();
			MacroNutrientQuantity = GetMacroNutrientQuantity(macroNutrientQuantity);
		}

		public double Calories { get; }
		public Allergen Allergens { get; }
		public Requirement Requirements { get; }
		public IDictionary<MacroNutrient, double> MacroNutrientQuantity { get; }

		private static IDictionary<MacroNutrient, double> GetMacroNutrientQuantity(
			IDictionary<string, double> macroNutrientQuantity) => macroNutrientQuantity
			.Select(x => new KeyValuePair<MacroNutrient, double>(x.Key.ToMacroNutrient(), x.Value))
			.ToDictionary(x => x.Key, x => x.Value);

		public bool Equals(AggregatedIngredientsDetails other)
		{
			return Calories.Equals(other.Calories) && Allergens == other.Allergens &&
			       Requirements == other.Requirements && Equals(MacroNutrientQuantity, other.MacroNutrientQuantity);
		}

		public override bool Equals(object obj)
		{
			return obj is AggregatedIngredientsDetails other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Calories.GetHashCode();
				hashCode = (hashCode * 397) ^ (int) Allergens;
				hashCode = (hashCode * 397) ^ (int) Requirements;
				hashCode = (hashCode * 397) ^ (MacroNutrientQuantity != null ? MacroNutrientQuantity.GetHashCode() : 0);
				return hashCode;
			}
		}
	}
}