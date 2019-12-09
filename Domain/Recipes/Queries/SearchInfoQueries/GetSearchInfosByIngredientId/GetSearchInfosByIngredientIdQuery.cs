using System;
using System.Collections.Generic;
using Domain.Common.Mediators.Queries;

namespace Domain.Recipes.Queries.SearchInfoQueries.GetSearchInfosByIngredientId
{
	public class GetSearchInfosByIngredientIdQuery : IQuery<ICollection<RecipeSearchInfo>>
	{
		public GetSearchInfosByIngredientIdQuery(Guid id) => Id = id;

		public Guid Id { get; set; }
	}
}