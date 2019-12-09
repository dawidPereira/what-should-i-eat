﻿using Domain.Common;
using Domain.Mediators.Query;
using Domain.Recipes.Entities;
using Domain.Recipes.Repositories;

namespace Domain.Recipes.Queries.SearchInfoQueries.GetSearchInfo
{
	public class GetSearchInfoQueryHandler : IQueryHandler<GetSearchInfoQuery, RecipeSearchInfo>
	{
		private readonly IRecipeRepository _recipeRepository;

		public GetSearchInfoQueryHandler(IRecipeRepository recipeRepository) => _recipeRepository = recipeRepository;

		public RecipeSearchInfo Handle(GetSearchInfoQuery query)  => 
			_recipeRepository.GetById(query.Id)?.CalculateSearchInfo() ?? 
			Exceptions<RecipeSearchInfo>.ThrowNotFoundException(nameof(Recipe), query.Id.ToString());
	}
}