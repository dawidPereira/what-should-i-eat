using System;
using Domain.Common.Mediators.Commands;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;

namespace Domain.Ingredients.Commands.Create
{
	public class CreateIngredientCommand: ICommand
	{
		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public Allergen Allergens { get; private set; }
		public Requirement Requirements { get; private set; }
		public MacroNutrientsSharesCollection MacroNutrientsSharesCollection { get; private set; }
	}
}