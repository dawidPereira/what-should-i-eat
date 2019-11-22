using System;
using System.Collections.Generic;
using System.Linq;
using WhatShouldIEat.Administration.Domain.Common;
using WhatShouldIEat.Administration.Domain.Common.Extensions;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.Administration.Domain.Recipe.Entities.Recipe;

namespace WhatShouldIEat.Administration.Domain.Recipe.Mappers
{
	using Recipe = Entities.Recipe.Recipe;
	
	public class RecipeIngredientValidator : IRecipeIngredientValidator
	{
		private readonly IIngredientRepository _ingredientRepository;

		public RecipeIngredientValidator(IIngredientRepository ingredientRepository) =>
			_ingredientRepository = ingredientRepository;
		
		public void ThrowExceptionIfAnyIngredientIdNotFound(IEnumerable<Guid> ingredientIds) => 
			ingredientIds.ForEach(ValidateIngredient);

		private void ValidateIngredient(Guid ingredientId)
		{
			if (!_ingredientRepository.ExistById(ingredientId))
				Exceptions<Ingredient>.ThrowNotFoundException(nameof(Ingredient), ingredientId.ToString());
		}
	}
}