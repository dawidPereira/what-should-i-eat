﻿using System;
using System.Collections.Generic;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;
using Domain.Ingredients.Queries.GetDetailsFormIngredients;
using Domain.Recipes.Entities;

namespace Domain.RecipesDetails.Entities
{
	public struct RecipeDetails : IValueObject<RecipeDetails>
	{
		public RecipeDetails(Identity<Guid> id,
			string name,
			Requirement requirements,
			Allergen allergens,
			MealType mealTypes,
			double calories,
			IDictionary<MacroNutrient, double> macroNutrientQuantity)
		{
			Id = id;
			Name = name;
			Requirements = requirements;
			Allergens = allergens;
			MealTypes = mealTypes;
			Calories = calories;
			MacroNutrientQuantity = macroNutrientQuantity;
		}

		public static RecipeDetails FromRecipeAndIngredientsDetails(Recipe recipe, 
			AggregatedIngredientsDetailsDto ingredientsDetails) =>
			new RecipeDetails(recipe.Id,
				recipe.Name,
				ingredientsDetails.Requirements,
				ingredientsDetails.Allergens,
				recipe.RecipeInfo.MealTypes,
				ingredientsDetails.Calories,
				ingredientsDetails.MacroNutrientQuantity);

		public Identity<Guid> Id { get; private set; }
		public string Name { get; private set; }	
		public Requirement Requirements { get; private set; }
		public Allergen Allergens { get; private set; }
		public MealType MealTypes { get; private set; }
		public double Calories { get; private set; }
		public IDictionary<MacroNutrient, double> MacroNutrientQuantity { get; private set; }

		public bool Equals(RecipeDetails other)
		{
			return Id.Equals(other.Id) 
			       && Name == other.Name 
			       && Requirements == other.Requirements 
			       && Allergens == other.Allergens 
			       && MealTypes == other.MealTypes 
			       && Calories.Equals(other.Calories) 
			       && Equals(MacroNutrientQuantity, other.MacroNutrientQuantity);
		}

		public override bool Equals(object obj)
		{
			return obj is RecipeDetails other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Id.GetHashCode();
				hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (int) Requirements;
				hashCode = (hashCode * 397) ^ (int) Allergens;
				hashCode = (hashCode * 397) ^ (int) MealTypes;
				hashCode = (hashCode * 397) ^ Calories.GetHashCode();
				hashCode = (hashCode * 397) ^ (MacroNutrientQuantity != null 
					           ? MacroNutrientQuantity.GetHashCode() 
					           : 0);
				return hashCode;
			}
		}
	}
}