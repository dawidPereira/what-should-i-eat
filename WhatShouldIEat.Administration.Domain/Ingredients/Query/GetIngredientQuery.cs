using WhatShouldIEat.Administration.Domain.Common.Query;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Dto.IngredientsDto;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Query
{
	public class GetIngredientQuery : IQuery<Ingredient>, IQuery<IngredientDto>
	{
		public GetIngredientQuery(Id<Ingredient> id) => Id = id;

		public Id<Ingredient> Id { get; set; }
	}
}