using System;
using Domain.Common.Mediators.Commands;

namespace Domain.RecipesDetails.Ingredients.Commands.Delete
{
	public class DeleteIngredientCommand : ICommand
	{
		public Guid Id { get; set; }
	}
}