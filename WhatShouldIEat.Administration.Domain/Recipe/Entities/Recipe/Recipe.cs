using System;
using System.Collections.Generic;
using System.Linq;
using WhatShouldIEat.Administration.Domain.Common.Extensions;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Recipe.Entities.Recipe
{
	public class Recipe
	{
		public Recipe(string name,
			string description,
			ICollection<Tuple<Ingredient, double>> recipeIngredients,
			RecipeDetails recipeDetails)
		{
			Id = new Id<Recipe>(Guid.NewGuid());
			Name = name;
			Description = description;
			RecipeIngredients = recipeIngredients;
			RecipeDetails = recipeDetails;
		}

		public Id<Recipe> Id { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public ICollection<Tuple<Ingredient, double>> RecipeIngredients { get; private set; }
		public RecipeDetails RecipeDetails { get; private set; }

		public double CalculateCalories() => RecipeIngredients.Sum(x => x.Item1.CalculateCalories(x.Item2));

		public void SetRecipeIngredients(ICollection<Tuple<Ingredient, double>> recipeIngredients)
		{
			recipeIngredients.ForEach(x => x.Item2.ThrowExceptionIfLowerThanZero());
			RecipeIngredients = recipeIngredients;
		}
	}
}