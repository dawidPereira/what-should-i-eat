using System.Collections;
using System.Collections.Generic;
using Domain.Common.ValueObjects;

namespace Domain.RecipesDetails.Recipes.Entities.Ingredient
{
	public class RecipeIngredientCollection : IValueObjectCollection<RecipeIngredient, RecipeIngredientCollection>
	{
		private readonly HashSet<RecipeIngredient> _recipeIngredients;

		public RecipeIngredientCollection(HashSet<RecipeIngredient> recipeIngredients) => 
			_recipeIngredients = recipeIngredients;

		private RecipeIngredientCollection Add(RecipeIngredient recipeIngredient)
		{
			
		}

		public IEnumerator<RecipeIngredient> GetEnumerator() => _recipeIngredients.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public bool Equals(RecipeIngredientCollection other)
		{
			if (ReferenceEquals(null, other)) return false;
			return ReferenceEquals(this, other) || Equals(_recipeIngredients, other._recipeIngredients);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((RecipeIngredientCollection) obj);
		}

		public override int GetHashCode() => _recipeIngredients != null ? _recipeIngredients.GetHashCode() : 0;
	}
}