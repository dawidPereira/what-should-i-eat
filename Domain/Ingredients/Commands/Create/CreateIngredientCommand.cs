using System;
using System.Collections.Generic;
using Domain.Common.Extensions;
using Domain.Common.Mediators.Commands;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;

namespace Domain.Ingredients.Commands.Create
{
	public class CreateIngredientCommand: ICommand
	{
		public CreateIngredientCommand(Guid id,
			string name,
			string allergens,
			string requirements,
			IEnumerable<MacroNutrientShare> shares)
		{
			Id = id;
			Name = name;
			Allergens = allergens.ToAllergens();
			Requirements = requirements.ToRequirements();
			Shares = shares;
		}
		
		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public Allergen Allergens { get; private set; }
		public Requirement Requirements { get; private set; }
		public IEnumerable<MacroNutrientShare> Shares { get; private set; }
	}
}