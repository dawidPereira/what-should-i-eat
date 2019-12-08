using WhatShouldIEat.Administration.Domain.Common;
using WhatShouldIEat.Administration.Domain.Common.Query;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Domain.Recipes.Queries.SearchInfoQueries.GetSearchInfo
{
	public class GetSearchInfoQueryHandler : IQueryHandler<GetSearchInfoQuery, RecipeSearchInfo>
	{
		private readonly IRecipeRepository _recipeRepository;

		public GetSearchInfoQueryHandler(IRecipeRepository recipeRepository)
		{
			_recipeRepository = recipeRepository;
		}

		public RecipeSearchInfo Handle(GetSearchInfoQuery query)  => 
			_recipeRepository.GetById(query.Id)?.CalculateSearchInfo() ?? 
			Exceptions<RecipeSearchInfo>.ThrowNotFoundException(nameof(Recipe), query.Id.ToString());
	}
}