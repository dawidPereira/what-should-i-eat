﻿using Domain.Common;
using Domain.Common.Mediators.Queries;
using Domain.Recipes.Entities;
using Domain.Recipes.Repositories;

namespace Domain.Recipes.Queries.GetById
{
	public class GetRecipeQueryHandler : IQueryHandler<GetRecipeQuery, RecipeDto>
	{
		private readonly IRecipeRepository _recipeRepository;

		public GetRecipeQueryHandler(IRecipeRepository recipeRepository) => 
			_recipeRepository = recipeRepository;

		public RecipeDto Handle(GetRecipeQuery query)
		{
			var recipe = _recipeRepository.GetById(query.Id);
			if(recipe == null) 
				Exceptions<RecipeDto>.ThrowNotFoundException(nameof(Recipe), query.Id.ToString());
			return RecipeDto.FromRecipe(recipe);
		}
	}
}