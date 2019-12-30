using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Common.Mediators.Queries;

namespace Domain.Ingredients.Queries.GetDetailsFormIngredients
{
	public class GetAggregatedIngredientsDetailsQuery : IQuery<AggregatedIngredientsDetailsDto>
	{
		private IEnumerable<Guid> Keys => IngredientsGrams.Keys;
		
		public GetAggregatedIngredientsDetailsQuery(IDictionary<Guid, double> ingredientsGrams)
		{
			IngredientsGrams = ingredientsGrams;
		}
		
		public IDictionary<Guid, double> IngredientsGrams { get; }

		public ICollection<Guid> GetIds() => Keys.ToList();

		public double GetGramsForIngredient(Guid ingredientId) => IngredientsGrams[ingredientId];
	}
}