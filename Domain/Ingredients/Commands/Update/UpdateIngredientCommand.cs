using System;
using System.Collections.Generic;
using Domain.Common.Mediators.Commands;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;

namespace Domain.Ingredients.Commands.Update
{
	public class UpdateIngredientCommand : ICommand
	{
		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public Allergen Allergens { get; private set; }
		public Requirement Requirements { get; private set; }
		public IEnumerable<Share> Shares { get; private set; }
	}
}