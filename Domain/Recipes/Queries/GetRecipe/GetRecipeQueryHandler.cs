using Domain.Common;
using Domain.Common.Query;
using Domain.Recipes.Entities;
using Domain.Recipes.Repositories;

namespace Domain.Recipes.Queries.GetRecipe
{
	public class GetRecipeQueryHandler : IQueryHandler<GetRecipeQuery, RecipeDto>
	{
		private readonly IRecipeRepository _recipeRepository;

		public GetRecipeQueryHandler(IRecipeRepository recipeRepository) => 
			_recipeRepository = recipeRepository;

		public RecipeDto Handle(GetRecipeQuery query) => _recipeRepository.GetById(query.Id)?.ToDto() ??
		                Exceptions<RecipeDto>.ThrowNotFoundException(nameof(Recipe), query.Id.ToString());
	}
}