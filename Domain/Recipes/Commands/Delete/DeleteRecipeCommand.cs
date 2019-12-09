using System;
using Domain.Common.Command;

namespace Domain.Recipes.Commands.Delete
{
	public class DeleteRecipeCommand : ICommand
	{
		public Guid Id { get; set; }
	}
}