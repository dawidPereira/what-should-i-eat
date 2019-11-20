using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Command
{
	public class RemoveIngredientCommand : ICommand
	{
		public Id<Ingredient> Id { get; set; }
	}
}