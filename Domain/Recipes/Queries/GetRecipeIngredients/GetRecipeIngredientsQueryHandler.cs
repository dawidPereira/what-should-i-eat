using System;
using System.Collections.Generic;
using Domain.Common.Mediators.Queries;
using Domain.Recipes.Repositories;

namespace Domain.Recipes.Queries.GetRecipeIngredients
{
	public class GetRecipeIngredientsQueryHandler : IQueryHandler<GetRecipeIngredientsQuery, IDictionary<Guid, double>>
	{
		private readonly IRecipeRepository _recipeRepository;

		public GetRecipeIngredientsQueryHandler(IRecipeRepository recipeRepository)
		{
			_recipeRepository = recipeRepository;
		}

		public IDictionary<Guid, double> Handle(GetRecipeIngredientsQuery query) =>
			_recipeRepository.GetRecipeIngredientsById(query.Id);
	}
}