using Domain.Common.ValueObjects;
using Domain.Ingredients.Entities;

namespace Domain.RecipesDetails.Recipes.Entities.Ingredients
{
	public class RecipeIngredient : IValueObject<RecipeIngredient>
	{
		public RecipeIngredient(Ingredient ingredient, double grams)
		{
			Ingredient = ingredient;
			Grams = grams;
		}
		
		public Ingredient Ingredient { get; }
		public double Grams { get; }

		public bool Equals(RecipeIngredient other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(Ingredient, other.Ingredient) && Grams.Equals(other.Grams);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((RecipeIngredient) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((Ingredient != null ? Ingredient.GetHashCode() : 0) * 397) ^ Grams.GetHashCode();
			}
		}
	}
}