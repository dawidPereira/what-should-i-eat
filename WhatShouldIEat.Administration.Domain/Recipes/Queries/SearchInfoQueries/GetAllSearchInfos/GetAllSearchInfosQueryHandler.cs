using System.Collections.Generic;
using System.Linq;
using WhatShouldIEat.Administration.Domain.Common.Query;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Domain.Recipes.Queries.SearchInfoQueries.GetAllSearchInfos
{
	public class GetAllSearchInfosQueryHandler : IQueryHandler<GetAllSearchInfosQuery, ICollection<RecipeSearchInfo>>
	{
		private readonly IRecipeRepository _recipeRepository;

		public GetAllSearchInfosQueryHandler(IRecipeRepository recipeRepository)
		{
			_recipeRepository = recipeRepository;
		}

		public ICollection<RecipeSearchInfo> Handle(GetAllSearchInfosQuery query) =>
			_recipeRepository.GetAll()
				.Select(x => x.CalculateSearchInfo())
				.ToList();
	}
}