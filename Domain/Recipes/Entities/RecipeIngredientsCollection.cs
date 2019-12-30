using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Domain.Common.ValueObjects;

namespace Domain.Recipes.Entities
{
	public class RecipeIngredientsCollection : IValueObjectCollection<RecipeIngredient, RecipeIngredientsCollection>
	{
		private readonly HashSet<RecipeIngredient> _recipeIngredients;

		public RecipeIngredientsCollection(IEnumerable<RecipeIngredient> recipeIngredients)
		{
			_recipeIngredients = recipeIngredients.ToHashSet();
		}

		public IEnumerator<RecipeIngredient> GetEnumerator() => _recipeIngredients.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public bool Equals(RecipeIngredientsCollection other)
		{
			if (ReferenceEquals(null, other)) return false;
			return ReferenceEquals(this, other) || Equals(_recipeIngredients, other._recipeIngredients);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((RecipeIngredientsCollection) obj);
		}

		public override int GetHashCode() => _recipeIngredients != null 
				? _recipeIngredients.GetHashCode() 
				: 0;

		public IDictionary<Guid, double> ToDictionary() => 
			_recipeIngredients.ToDictionary(x => x.IngredientId.Value, x => x.Grams);
	}
}