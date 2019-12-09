using System;
using Domain.Mediators.Query;

namespace Domain.Ingredients.Queries.GetIngredient
{
	public class GetIngredientQuery : IQuery<IngredientDto>
	{
		public Guid Id { get; set; }
	}
}