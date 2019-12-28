using System;
using Domain.Common.Mediators.Commands;

namespace Domain.Ingredients.Commands.Delete
{
	public class DeleteIngredientCommand: ICommand
	{
		public DeleteIngredientCommand(Guid id) => Id = id;

		public Guid Id { get; private set;}
	}
}