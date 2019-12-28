using System;
using Domain.Common.Mediators.Queries;

namespace Domain.Ingredients.Queries.Get
{
	public class GetIngredientQuery : IQuery<IngredientDto>
	{
		public GetIngredientQuery(Guid ingredientId) => IngredientId = ingredientId;
		
		public Guid IngredientId{ get; }
	}
}