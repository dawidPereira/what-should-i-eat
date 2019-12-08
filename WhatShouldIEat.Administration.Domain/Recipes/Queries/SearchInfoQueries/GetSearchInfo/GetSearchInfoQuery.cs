using System;
using WhatShouldIEat.Administration.Domain.Common.Query;

namespace WhatShouldIEat.Administration.Domain.Recipes.Queries.SearchInfoQueries.GetSearchInfo
{
	public class GetSearchInfoQuery : IQuery<RecipeSearchInfo>
	{
		public GetSearchInfoQuery(Guid id)
		{
			Id = id;
		}
		
		public Guid Id { get; set; }
	}
}