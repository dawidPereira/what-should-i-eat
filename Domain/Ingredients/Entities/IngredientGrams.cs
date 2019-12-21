using Domain.Common.ValueObjects;

namespace Domain.Ingredients.Entities
{
	public struct IngredientGrams : IValueObject<IngredientGrams>
	{
		public IngredientGrams(Ingredient ingredient, double grams)
		{
			Ingredient = ingredient;
			Grams = grams;
		}
		public Ingredient Ingredient{ get; }
		public double Grams { get; }

		public bool Equals(IngredientGrams other) => 
			Equals(Ingredient, other.Ingredient) && Grams.Equals(other.Grams);

		public override bool Equals(object obj) => 
			obj is IngredientGrams other && Equals(other);

		public override int GetHashCode()
		{
			unchecked
			{
				return ((Ingredient != null ? Ingredient.GetHashCode() : 0) * 397) ^ Grams.GetHashCode();
			}
		}
	}
}