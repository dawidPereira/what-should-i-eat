using System.Collections.Generic;
using Domain.Common.Mediators.Queries;
using Domain.RecipesDetails.Recipes.Repositories;

namespace Domain.RecipesDetails.Recipes.Queries.GetBasicInfos
{
	public class
		GetRecipesBasicInfosQueryHandler : IQueryHandler<GetRecipesBasicInfosQuery, ICollection<RecipeBasicInfo>>
	{
		private readonly IRecipeRepository _recipeRepository;

		public GetRecipesBasicInfosQueryHandler(IRecipeRepository recipeRepository) => 
			_recipeRepository = recipeRepository;

		public ICollection<RecipeBasicInfo> Handle(GetRecipesBasicInfosQuery query) => 
			_recipeRepository.GetBasicInfos() ?? new List<RecipeBasicInfo>();
	}
}