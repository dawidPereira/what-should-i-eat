using System;
using WhatShouldIEat.Administration.Domain.Common.Command;

namespace WhatShouldIEat.Administration.Domain.Recipes.Commands.DeleteRecipeCommand
{
	public class DeleteRecipeCommand : ICommand
	{
		public Guid Id { get; set; }
	}
}