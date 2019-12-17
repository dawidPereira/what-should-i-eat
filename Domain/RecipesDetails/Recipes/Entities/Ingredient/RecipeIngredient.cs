using Domain.Common.ValueObjects;

namespace Domain.RecipesDetails.Recipes.Entities.Ingredient
{
	public sealed class RecipeIngredient : IValueObject<RecipeIngredient>
	{
		public RecipeIngredient(Ingredient ingredient, double grams)
		{
			Ingredient = ingredient;
			Grams = grams;
		}

		public Ingredients.Entities.Ingredient Ingredient { get; }
		public double Grams { get; }

		public bool Equals(RecipeIngredient other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(Ingredient, other.Ingredient) && Grams.Equals(other.Grams);
		}

		public override bool Equals(object obj) => 
			ReferenceEquals(this, obj) || obj is RecipeIngredient other && Equals(other);

		public override int GetHashCode()
		{
			unchecked
			{
				return ((Ingredient != null ? Ingredient.GetHashCode() : 0) * 397) ^ Grams.GetHashCode();
			}
		}
	}
}