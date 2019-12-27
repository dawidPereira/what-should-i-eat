using System;
using System.Collections.Generic;

namespace Infrastructure.Entities.Ingredient
{
	public sealed class Ingredient
	{
		public Ingredient(Guid id, string name, int allergens, int requirements, ICollection<MacroNutrientShares> macroNutrientShares)
		{
			Id = id;
			Name = name;
			Allergens = allergens;
			Requirements = requirements;
			MacroNutrientShares = macroNutrientShares;
		}
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int Allergens { get; set; }
		public int Requirements { get;  set; }
		public ICollection<MacroNutrientShares> MacroNutrientShares { get;  set; }
	}
}