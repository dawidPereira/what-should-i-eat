using System;
using Domain.Mediators.Command;

namespace Domain.Recipes.Commands.Delete
{
	public class DeleteRecipeCommand : ICommand
	{
		public Guid Id { get; set; }
	}
}