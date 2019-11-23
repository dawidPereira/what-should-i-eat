using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.Query;
using WhatShouldIEat.Administration.Domain.Ingredients.Dtos;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Queries
{
	public class GetIngredientsBasicInfoQuery : IQuery<ICollection<IngredientBasicInfo>>
	{
	}
}