﻿using System;
using System.Collections.Generic;
using Domain.Ingredients.Entities;
using Domain.Mediators.Command;

namespace Domain.Ingredients.Commands.Update
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