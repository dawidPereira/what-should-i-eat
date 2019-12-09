using System.Collections.Generic;
using System.Linq;
using Domain.Common.Mediators.Queries;
using Domain.Recipes.Repositories;

namespace Domain.Recipes.Queries.SearchInfoQueries.GetAllSearchInfos
{
	public class GetAllSearchInfosQueryHandler : IQueryHandler<GetAllSearchInfosQuery, ICollection<RecipeSearchInfo>>
	{
		private readonly IRecipeRepository _recipeRepository;

		public GetAllSearchInfosQueryHandler(IRecipeRepository recipeRepository) => 
			_recipeRepository = recipeRepository;

		public ICollection<RecipeSearchInfo> Handle(GetAllSearchInfosQuery query) =>
			_recipeRepository.GetAll()
				.Select(x => x.CalculateSearchInfo())
				.ToList();
	}
}