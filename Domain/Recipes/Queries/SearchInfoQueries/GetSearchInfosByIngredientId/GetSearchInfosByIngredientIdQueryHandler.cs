using System.Collections.Generic;
using System.Linq;
using Domain.Common.Mediators.Queries;
using Domain.Recipes.Repositories;

namespace Domain.Recipes.Queries.SearchInfoQueries.GetSearchInfosByIngredientId
{
	public class GetSearchInfosByIngredientIdQueryHandler : IQueryHandler<GetSearchInfosByIngredientIdQuery, ICollection<RecipeSearchInfo>>
	{
		private readonly IRecipeRepository _recipeRepository;

		public GetSearchInfosByIngredientIdQueryHandler(IRecipeRepository recipeRepository) => 
			_recipeRepository = recipeRepository;

		public ICollection<RecipeSearchInfo> Handle(GetSearchInfosByIngredientIdQuery query)=>
			_recipeRepository.GetRecipesByIngredientId(query.Id)
				.Select(x => x.CalculateSearchInfo())
				.ToList();
	}
}