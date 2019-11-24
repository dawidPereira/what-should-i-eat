using System;
using WhatShouldIEat.Administration.Domain.Common.Query;

namespace WhatShouldIEat.Administration.Domain.Recipes.Queries.GetRecipeQuery
{
	public class GetRecipeQuery : IQuery<RecipeDto>
	{
		public Guid Id { get; set; }
	}
}