using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Common.Mediators.Queries;
using Domain.Recipes.Repositories;

namespace Domain.Recipes.Queries.GetAllRecipeIds
{
	public class GetAllRecipesIdsQueryHandler : IQueryHandler<GetAllRecipesIdsQuery, ICollection<Guid>>
	{
		private readonly IRecipeRepository _recipeRepository;

		public GetAllRecipesIdsQueryHandler(IRecipeRepository recipeRepository)
		{
			_recipeRepository = recipeRepository;
		}

		public ICollection<Guid> Handle(GetAllRecipesIdsQuery query) => _recipeRepository.GetAllIds()
			.ToList();
	}
}