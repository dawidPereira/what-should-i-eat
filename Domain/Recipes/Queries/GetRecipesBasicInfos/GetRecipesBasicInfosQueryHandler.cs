using System.Collections.Generic;
using Domain.Common.Query;
using Domain.Recipes.Repositories;

namespace Domain.Recipes.Queries.GetRecipesBasicInfos
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