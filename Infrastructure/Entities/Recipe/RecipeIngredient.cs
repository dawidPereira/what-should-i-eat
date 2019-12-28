using System;

namespace Infrastructure.Entities.Recipe
{
	public class RecipeIngredient
	{
		public RecipeIngredient(Guid recipeId, Guid ingredientId, double grams)
		{
			RecipeId = recipeId;
			IngredientId = ingredientId;
			Grams = grams;
		}
		public Guid RecipeId { get; private set; }
		public Guid IngredientId { get; private set; }
		public double Grams { get; private set; }
		
		public static RecipeIngredient FromDomainRecipe(Guid id, Domain.Recipes.Entities.RecipeIngredient recipeIngredient)
			=> new RecipeIngredient(id, recipeIngredient.IngredientId.Value, recipeIngredient.Grams);
	}
}