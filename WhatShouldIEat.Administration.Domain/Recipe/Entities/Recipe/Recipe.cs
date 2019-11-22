using System;
using System.Collections.Generic;
using System.Linq;
using WhatShouldIEat.Administration.Domain.Common;
using WhatShouldIEat.Administration.Domain.Common.Extensions;
using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Recipe.Command;

namespace WhatShouldIEat.Administration.Domain.Recipe.Entities.Recipe
{
	public class Recipe
	{
		public Recipe(Guid id,
			string name,
			string description,
			ICollection<RecipeIngredient> recipeIngredients,
			RecipeDetails recipeDetails)
		{
			Id = id;
			Name = name;
			Description = description;
			RecipeIngredients = recipeIngredients;
			RecipeDetails = recipeDetails;
		}

		public Guid Id { get; private set; }
		public string Name { get;  set; }
		public string Description { get; private set; }
		public ICollection<RecipeIngredient> RecipeIngredients { get; private set; }
		public RecipeDetails RecipeDetails { get; private set; }

		public double CalculateCalories() => RecipeIngredients.Sum(x => x.Ingredient.CalculateCalories(x.Grams));

		public void SetRecipeIngredients(ICollection<RecipeIngredient> recipeIngredients)
		{
			recipeIngredients.ForEach(x => x.Grams.ThrowExceptionIfLowerThanZero(nameof(RecipeIngredient.Grams)));
			RecipeIngredients = recipeIngredients;
		}

		public void SetRecipeDetails(RecipeDetails recipeDetails) => RecipeDetails = recipeDetails ?? 
		                throw new ArgumentNullException(nameof(RecipeDetails), ExceptionMessages.ValueCannotBeNull);
	}
}