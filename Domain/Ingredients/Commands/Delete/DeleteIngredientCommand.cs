using System;
using Domain.Common.Mediators.Commands;
using Domain.Common.ValueObjects;

namespace Domain.Ingredients.Commands.Delete
{
	public class DeleteIngredientCommand: ICommand
	{
		public DeleteIngredientCommand(Identity<Guid> id) => Id = id;

		public Identity<Guid> Id { get; private set;}
	}
}