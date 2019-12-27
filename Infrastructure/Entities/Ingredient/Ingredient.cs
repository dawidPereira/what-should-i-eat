using System;
using System.Collections.Generic;

namespace Infrastructure.Entities.Ingredient
{
	public class Ingredient
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int Allergens { get; set; }
		public int Requirements { get;  set; }
		public virtual ICollection<MacroNutrientShares> MacroNutrientShares { get;  set; }
	}
}