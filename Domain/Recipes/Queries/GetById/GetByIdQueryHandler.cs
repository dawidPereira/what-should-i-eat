using Domain.Common;
using Domain.Common.Mediators.Queries;
using Domain.Recipes.Entities;
using Domain.Recipes.Repositories;

namespace Domain.Recipes.Queries.GetById
{
	public class GetByIdQueryHandler : IQueryHandler<GetByIdQuery, RecipeDto>
	{
		private readonly IRecipeRepository _recipeRepository;

		public GetByIdQueryHandler(IRecipeRepository recipeRepository) => 
			_recipeRepository = recipeRepository;

		public RecipeDto Handle(GetByIdQuery query)
		{
			var recipe = _recipeRepository.GetById(query.Id);
			if(recipe == null) 
				Exceptions<RecipeDto>.ThrowNotFoundException(nameof(Recipe), query.Id.ToString());
			return RecipeDto.FromRecipe(recipe);
		}
	}
}