using System;
using Domain.Common.Mediators.Commands;

namespace Domain.Recipes.Commands.Delete
{
	public class DeleteRecipeCommand : ICommand
	{
		public Guid Id { get; set; }
	}
}