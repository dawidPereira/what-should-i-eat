﻿using System;
using System.Collections.Generic;
using System.Linq;
using Domain.RecipesDetails.Ingredients.Commands.Update;
using Domain.RecipesDetails.Ingredients.Entities.MacroNutrients;
using Domain.RecipesDetails.Ingredients.Queries.GetIngredient;
using Domain.RecipesDetails.Recipes.Entities;

namespace Domain.RecipesDetails.Ingredients.Entities
{
	public class Ingredient
	{
		private Ingredient(Guid id,
			string name,
			Allergen allergens,
			Requirement requirements,
			ICollection<IngredientMacroNutrient> macroNutrientsParticipants)
		{
			Name = name;
			Id = id;
			Allergens = allergens;
			Requirements = requirements;
			MacroNutrientsParticipants = macroNutrientsParticipants;
		}

		public string Name { get; private set; }
		public Guid Id { get; private set; }
		public Allergen Allergens { get; private set; }
		public Requirement Requirements { get; private set; }
		public ICollection<IngredientMacroNutrient> MacroNutrientsParticipants { get; private set; }
		public ICollection<RecipeIngredient> RecipeIngredients { get; private set; }

		public static Ingredient Create(
			Guid id,
			string name,
			Allergen allergens,
			Requirement requirements,
			ICollection<IngredientMacroNutrient> macroNutrientsParticipation) => 
			new Ingredient(id, name, allergens, requirements, macroNutrientsParticipation);

		public double CalculateCalories(double grams) =>
			MacroNutrientsParticipants.Sum(x => CalorieCalculator.CalculateCalories(x.MacroNutrient, x.ParticipationInIngredient * grams));

		public void Update(UpdateIngredientCommand command)
		{
			Name = command.Name;
			Allergens = command.Allergens;
			Requirements = command.Requirements;
			MacroNutrientsParticipants = command.MacroNutrientsParticipation;
		}

		public IngredientDto ToDto() => new IngredientDto 
		{
			Id = Id,
			Name = Name,
			Allergens = Allergens,
			Requirements = Requirements,
			MacroNutrientsParticipation = MacroNutrientsParticipants
		};

		public IDictionary<MacroNutrient, double> GetMacroNutrientQuantity(double grams)
		{
			var result = MacroNutrientsParticipants.ToDictionary(x => x.MacroNutrient,
				x => x.ParticipationInIngredient * grams);
			return result;
		}
	}
}