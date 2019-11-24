using WhatShouldIEat.Administration.Domain.Common;
using WhatShouldIEat.Administration.Domain.Common.Query;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Domain.Recipes.Queries.GetRecipeQuery
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