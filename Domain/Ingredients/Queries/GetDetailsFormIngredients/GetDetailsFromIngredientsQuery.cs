using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Common.Mediators.Queries;
using Domain.Common.ValueObjects;

namespace Domain.Ingredients.Queries.GetDetailsFormIngredients
{
	public class GetDetailsFromIngredientsQuery : IQuery<AggregatedIngredientsDetailsDto>
	{
		private IEnumerable<Identity<Guid>> Keys => IngredientsGrams.Keys;
		
		public GetDetailsFromIngredientsQuery(IDictionary<Identity<Guid>, double> ingredientsGrams)
		{
			IngredientsGrams = ingredientsGrams;
		}
		
		public IDictionary<Identity<Guid>, double> IngredientsGrams { get; }

		public ICollection<Identity<Guid>> GetIds() => Keys.ToList();

		public double GetGramsForIngredient(Identity<Guid> ingredientId) => IngredientsGrams[ingredientId];
	}
}