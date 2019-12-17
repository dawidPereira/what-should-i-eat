using System;
using Domain.Common.Mediators.Queries;
using Domain.Common.ValueObjects;

namespace Domain.Ingredients.Queries.Get
{
	public class GetIngredientQuery : IQuery<IngredientDto>
	{
		public GetIngredientQuery(Identity<Guid> ingredientId) => IngredientId = ingredientId;
		
		public Identity<Guid> IngredientId{ get; }
	}
}