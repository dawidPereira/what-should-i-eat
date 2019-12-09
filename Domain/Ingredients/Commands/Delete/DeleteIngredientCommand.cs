using System;
using Domain.Common.Command;

namespace Domain.Ingredients.Commands.Delete
{
	public class DeleteIngredientCommand : ICommand
	{
		public Guid Id { get; set; }
	}
}