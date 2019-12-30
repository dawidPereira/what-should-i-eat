using System;
using System.Collections.Generic;
using Domain.Common.Mediators.Queries;

namespace Domain.Recipes.Queries.GetRecipeIngredients
{
	public class GetRecipeIngredientsQuery : IQuery<IDictionary<Guid, double>>
	{
		public Guid Id { get; set; }

		public GetRecipeIngredientsQuery(Guid id)
		{
			Id = id;
		}
	}
}