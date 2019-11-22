using System;
using WhatShouldIEat.Administration.Domain.Common.Command;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Command
{
	public class RemoveIngredientCommand : ICommand
	{
		public Guid Id { get; set; }
	}
}