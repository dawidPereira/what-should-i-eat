using System;
using System.Collections.Generic;
using System.Linq;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Create;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Update;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;
using WhatShouldIEat.Administration.Domain.Ingredients.Queries.GetIngredient;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Entities
{
	public class Ingredient
	{
		private  Ingredient(Guid id,
			string name,
			Allergen allergens,
			Requirement requirements,
			ICollection<IngredientMacroNutrient> macroNutrientsParticipation)
		{
			Name = name;
			Id = id;
			Allergens = allergens;
			Requirements = requirements;
			MacroNutrientsParticipation = macroNutrientsParticipation;
		}

		public string Name { get; private set; }
		public Guid Id { get; private set; }
		public Allergen Allergens { get; private set; }
		public Requirement Requirements { get; private set; }
		public ICollection<IngredientMacroNutrient> MacroNutrientsParticipation { get; private set; }
		public ICollection<RecipeIngredient> RecipeIngredients { get; private set; }

		public static Ingredient Create(
			Guid id,
			string name,
			Allergen allergens,
			Requirement requirements,
			ICollection<IngredientMacroNutrient> macroNutrientsParticipation) => 
			new Ingredient(id, name, allergens, requirements, macroNutrientsParticipation);

		public double CalculateCalories(double grams) =>
			MacroNutrientsParticipation.Sum(x => x.MacroNutrient.CalculateCalories(x.ParticipationInIngredient * grams));

		public void Update(UpdateIngredientCommand command)
		{
			Name = command.Name;
			Allergens = command.Allergens;
			Requirements = command.Requirements;
			MacroNutrientsParticipation = command.MacroNutrientsParticipation;
		}

		public IngredientDto ToDto() => new IngredientDto 
		{
			Id = Id,
			Name = Name,
			Allergens = Allergens,
			Requirements = Requirements,
			MacroNutrientsParticipation = MacroNutrientsParticipation
		};
	}
}