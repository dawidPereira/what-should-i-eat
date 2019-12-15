using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Common.Extensions;
using Domain.Ingredients.Entities.MacroNutirents;

namespace Domain.Ingredients.Entities
{
	public class Ingredient
	{
		public Ingredient(
			Guid id,
			string name,
			Allergen allergens,
			Requirement requirements,
			MacroNutrientsShares macroNutrientsShares)
		{
			Id = SetId(id);
			Name = SetName(name);
			Allergens = allergens;
			Requirements = requirements;
			MacroNutrientsShares = macroNutrientsShares;
		}

		public Guid Id { get; }
		public string Name { get; }
		public Allergen Allergens { get; }
		public Requirement Requirements { get; }
		public MacroNutrientsShares MacroNutrientsShares { get; }
		
		public double CalculateCalories(double grams) =>
			MacroNutrientsShares.Sum(x => x.MacroNutrient.CalculateCalories(x.ParticipationInIngredient * grams));

		public IDictionary<MacroNutrient, double> GetMacroNutrientQuantity(double grams)
		{
			var result = MacroNutrientsShares.ToDictionary(
				x => x.MacroNutrient,
				x => x.ParticipationInIngredient * grams);
			return result;
		}

		private static Guid SetId(Guid id)
		{
			if(!id.HasGuidValue()) 
				throw new ArgumentException("Incorrect guid value.");
			return id;
		}

		private static string SetName(string name)
		{
			if(name == null)
				throw new ArgumentNullException(nameof(name), "Ingredient name can not be empty.");
			return name;
		}
	}
}