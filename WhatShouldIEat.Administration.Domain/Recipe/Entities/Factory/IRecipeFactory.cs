using WhatShouldIEat.Administration.Domain.Recipe.Command;

namespace WhatShouldIEat.Administration.Domain.Recipe.Entities.Factory
{
	using Recipe = Recipe.Recipe;
	public interface IRecipeFactory
	{
		Recipe Build(CreateRecipeCommand command);
	}
}