using System.Collections.Generic;
using System.Linq;
using Domain.Common.Mediators.Queries;
using Domain.RecipesDetails.Filters.FiltersCriteria;
using Domain.RecipesDetails.Repositories;

namespace Domain.RecipesDetails.Queries.Find
{
	public class FindRecipeDetailsQueryHandler : IQueryHandler<FindRecipeDetailsQuery, IEnumerable<RecipeDetailsDto>>
	{
		private readonly IRecipeDetailsRepository _recipeDetailsRepository;
		private const double Deviation = 0.1;

		public FindRecipeDetailsQueryHandler(IRecipeDetailsRepository recipeDetailsRepository)
		{
			_recipeDetailsRepository = recipeDetailsRepository;
		}

		public IEnumerable<RecipeDetailsDto> Handle(FindRecipeDetailsQuery query)
		{
			var filterCriteria = new RecipeSearchFilterCriteria(query, Deviation);
			var recipes = _recipeDetailsRepository.FindRecipesDetails(filterCriteria);
			return recipes.Select(RecipeDetailsDto.FromRecipeDetails)
				.ToList();
		}
	}
}