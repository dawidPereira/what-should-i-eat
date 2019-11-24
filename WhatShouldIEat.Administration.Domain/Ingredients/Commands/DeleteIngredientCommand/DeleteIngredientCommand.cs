using System;
using WhatShouldIEat.Administration.Domain.Common.Command;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Commands.DeleteIngredientCommand
{
	public class DeleteIngredientCommand : ICommand
	{
		public Guid Id { get; set; }
	}
}