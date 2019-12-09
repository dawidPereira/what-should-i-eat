using System;
using Domain.Mediators.Command;

namespace Domain.Ingredients.Commands.Delete
{
	public class DeleteIngredientCommand : ICommand
	{
		public Guid Id { get; set; }
	}
}