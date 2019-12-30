using System;
using System.Collections.Generic;
using Domain.Common.Mediators.Queries;

namespace Domain.Recipes.Queries.GetAllRecipeIds
{
	public class GetAllRecipesIdsQuery : IQuery<ICollection<Guid>>
	{
	}
}