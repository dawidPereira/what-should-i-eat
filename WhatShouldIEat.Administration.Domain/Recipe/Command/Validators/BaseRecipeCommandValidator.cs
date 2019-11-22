using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common;
using WhatShouldIEat.Administration.Domain.Common.Extensions;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.Administration.Domain.Recipe.Repository;

namespace WhatShouldIEat.Administration.Domain.Recipe.Command.Validators
{
	public abstract class BaseRecipeCommandValidator
	{
		private readonly IIngredientRepository _ingredientRepository;
		protected readonly IRecipeRepository RecipeRepository;

		protected BaseRecipeCommandValidator(IIngredientRepository ingredientRepository, IRecipeRepository recipeRepository)
		{
			_ingredientRepository = ingredientRepository;
			RecipeRepository = recipeRepository;
		}

		protected void ThrowExceptionIfAnyIngredientIdNotFound(IEnumerable<Guid> ingredientIds) => 
			ingredientIds.ForEach(ValidateIngredient);

		private void ValidateIngredient(Guid ingredientId)
		{
			if (!_ingredientRepository.ExistById(ingredientId))
				Exceptions<Ingredient>.ThrowNotFoundException(nameof(Ingredient), ingredientId.ToString());
		}
	}
}