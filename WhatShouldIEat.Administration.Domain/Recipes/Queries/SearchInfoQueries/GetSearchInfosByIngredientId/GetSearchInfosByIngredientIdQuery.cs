using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.Query;

namespace WhatShouldIEat.Administration.Domain.Recipes.Queries.SearchInfoQueries.GetSearchInfosByIngredientId
{
	public class GetSearchInfosByIngredientIdQuery : IQuery<ICollection<RecipeSearchInfo>>
	{
		public GetSearchInfosByIngredientIdQuery(Guid id)
		{
			Id = id;
		}
		
		public Guid Id { get; set; }
	}
}