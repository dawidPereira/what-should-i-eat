using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Commands.Update
{
	public class UpdateIngredientCommand : ICommand
	{
		public Guid Id { get; set; }
		public string Name { get;  set; }
		public Allergen Allergens { get;  set; }
		public Requirement Requirements { get;  set; }
		public ICollection<IngredientMacroNutrient> MacroNutrientsParticipation { get;  set; }
	}
}