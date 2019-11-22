using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Recipe.Entities.Recipe;

namespace WhatShouldIEat.Administration.Domain.Recipe.Mappers
{
	public interface IRecipeIngredientValidator
	{
		void ThrowExceptionIfAnyIngredientIdNotFound(IEnumerable<Guid> ingredientIds);
	}
}