using System;
using System.Collections.Generic;
using Domain.Common.Mediators.Commands;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;

namespace Domain.Ingredients.Commands.Create
{
	public class CreateIngredientCommand: ICommand
	{
		public CreateIngredientCommand(Identity<Guid> id,
			string name,
			Allergen allergens,
			Requirement requirements,
			IEnumerable<MacroNutrientShare> shares)
		{
			Id = id;
			Name = name;
			Allergens = allergens;
			Requirements = requirements;
			Shares = shares;
		}
		
		public Identity<Guid> Id { get; private set; }
		public string Name { get; private set; }
		public Allergen Allergens { get; private set; }
		public Requirement Requirements { get; private set; }
		public IEnumerable<MacroNutrientShare> Shares { get; private set; }
	}
}