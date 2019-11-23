using System;
using WhatShouldIEat.Administration.Domain.Common.Query;
using WhatShouldIEat.Administration.Domain.Ingredients.Dtos;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Queries
{
	public class GetIngredientQuery : IQuery<Ingredient>, IQuery<IngredientDto>
	{
		public Guid Id { get; set; }
	}
}