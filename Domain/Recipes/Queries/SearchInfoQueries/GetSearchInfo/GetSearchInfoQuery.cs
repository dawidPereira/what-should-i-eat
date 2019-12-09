using System;
using Domain.Mediators.Query;

namespace Domain.Recipes.Queries.SearchInfoQueries.GetSearchInfo
{
	public class GetSearchInfoQuery : IQuery<RecipeSearchInfo>
	{
		public GetSearchInfoQuery(Guid id) => Id = id;

		public Guid Id { get; set; }
	}
}