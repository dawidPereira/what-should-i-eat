using System.Collections.Generic;
using System.Linq;
using WhatShouldIEat.Administration.Domain.Common.Query;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Domain.Recipes.Queries.SearchInfoQueries.GetSearchInfosByIngredientId
{
	public class GetSearchInfosByIngredientIdQueryHandler : IQueryHandler<GetSearchInfosByIngredientIdQuery, ICollection<RecipeSearchInfo>>
	{
		private readonly IRecipeRepository _recipeRepository;

		public GetSearchInfosByIngredientIdQueryHandler(IRecipeRepository recipeRepository)
		{
			_recipeRepository = recipeRepository;
		}

		public ICollection<RecipeSearchInfo> Handle(GetSearchInfosByIngredientIdQuery query)=>
			_recipeRepository.GetRecipesByIngredientId(query.Id)
				.Select(x => x.CalculateSearchInfo())
				.ToList();
	}
}