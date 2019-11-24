using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.Query;
using WhatShouldIEat.Administration.Domain.Recipes.Dtos;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Domain.Recipes.Queries.Handlers
{
	public class GetRecipesBasicInfosQueryHandler : IQueryHandler<GetRecipesBasicInfosQuery, ICollection<RecipeBasicInfo>>
	{
		private readonly IRecipeRepository _recipeRepository;

		public GetRecipesBasicInfosQueryHandler(IRecipeRepository recipeRepository) => 
			_recipeRepository = recipeRepository;

		public ICollection<RecipeBasicInfo> Handle(GetRecipesBasicInfosQuery query) => 
			_recipeRepository.GetBasicInfos() ?? new List<RecipeBasicInfo>();
	}
}