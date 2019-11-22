using System;
using WhatShouldIEat.Administration.Domain.Common.Query;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Dto;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Query
{
	public class GetIngredientQuery : IQuery<Ingredient>, IQuery<IngredientDto>
	{
		public Guid Id { get; set; }
	}
}