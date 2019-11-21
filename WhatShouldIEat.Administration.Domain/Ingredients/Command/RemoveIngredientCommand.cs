using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Command
{
	public class RemoveIngredientCommand : ICommand
	{
		public Id<Ingredient> Id { get; set; }
	}
}