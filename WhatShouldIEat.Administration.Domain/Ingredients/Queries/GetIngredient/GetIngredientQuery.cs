using System;
using WhatShouldIEat.Administration.Domain.Common.Query;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Queries.GetIngredient
{
	public class GetIngredientQuery : IQuery<IngredientDto>
	{
		public Guid Id { get; set; }
	}
}