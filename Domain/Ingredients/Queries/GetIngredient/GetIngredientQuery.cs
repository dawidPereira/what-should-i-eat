using System;
using Domain.Common.Mediators.Queries;

namespace Domain.Ingredients.Queries.GetIngredient
{
	public class GetIngredientQuery : IQuery<IngredientDto>
	{
		public Guid Id { get; set; }
	}
}