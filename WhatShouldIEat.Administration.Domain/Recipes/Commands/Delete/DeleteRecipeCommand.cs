using System;
using WhatShouldIEat.Administration.Domain.Common.Command;

namespace WhatShouldIEat.Administration.Domain.Recipes.Commands.Delete
{
	public class DeleteRecipeCommand : ICommand
	{
		public Guid Id { get; set; }
	}
}