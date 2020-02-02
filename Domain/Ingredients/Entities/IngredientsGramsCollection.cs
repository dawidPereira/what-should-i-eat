using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Domain.Common.Extensions;
using Domain.Common.ValueObjects;

namespace Domain.Ingredients.Entities
{
	public class IngredientsGramsCollection : IValueObjectCollection<IngredientGrams, IngredientsGramsCollection>
	{
		private readonly HashSet<IngredientGrams> _ingredientsGrams;

		public IngredientsGramsCollection(IEnumerable<IngredientGrams> ingredientsGrams)
		{
			_ingredientsGrams = ingredientsGrams.ToHashSet();
		}
		
		public double CalculateCalories() =>
			_ingredientsGrams.Sum(x => x.Ingredient.CalculateCalories(x.Grams));
		
		public Allergen GetAllergens() =>
			_ingredientsGrams.Select(x => x.Ingredient.Allergens)
				.Aggregate(Allergen.None, (acc, el) => acc | el);

		public Requirement GetRequirements() =>
			_ingredientsGrams.Select(x => x.Ingredient.Requirements)
				.Aggregate(Requirement.None, (acc, el) => acc | el);

		public IDictionary<string, double> GetMacroNutrientQuantity() => _ingredientsGrams
			.Select(x => x.Ingredient.GetMacroNutrientQuantity(x.Grams))
			.MergeDictionary();

		public IEnumerator<IngredientGrams> GetEnumerator() => _ingredientsGrams.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public bool Equals(IngredientsGramsCollection other)
		{
			if (ReferenceEquals(null, other)) return false;
			return ReferenceEquals(this, other) || Equals(_ingredientsGrams, other._ingredientsGrams);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((IngredientsGramsCollection) obj);
		}

		public override int GetHashCode() => _ingredientsGrams != null ? _ingredientsGrams.GetHashCode() : 0;
		
	}
}