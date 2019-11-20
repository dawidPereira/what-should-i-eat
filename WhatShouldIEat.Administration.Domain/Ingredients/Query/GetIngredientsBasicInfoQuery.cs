using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.Query;
using WhatShouldIEat.Administration.Domain.Dto.IngredientsDto;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Query
{
	public class GetIngredientsBasicInfoQuery : IQuery<ICollection<IngredientBasicInfo>>
	{
	}
}