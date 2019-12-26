using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common.Mediators;
using Domain.Common.Mediators.Commands;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Queries.GetDetailsFormIngredients;
using Domain.Recipes.Entities;
using Domain.Recipes.Repositories;
using Domain.RecipesDetails.Entities;

namespace Domain.RecipesDetails.Commands
{
	public class BuildAllRecipesDetailsCommandHandler : ICommandHandler<BuildAllRecipesDetailsCommand>
	{
		private readonly IMediator _mediator;
		private readonly IRecipeRepository _recipeRepository;
		private readonly IRecipeDetailsRepository _recipeDetailsRepository;

		public BuildAllRecipesDetailsCommandHandler(IRecipeRepository recipeRepository,
			IRecipeDetailsRepository recipeDetailsRepository)
		{
			_recipeRepository = recipeRepository;
			_recipeDetailsRepository = recipeDetailsRepository;
		}

		public Result Handle(BuildAllRecipesDetailsCommand command)
		{
			var recipes = _recipeRepository.GetAll();
			var recipesDetails = recipes.Select(NewRecipeDetails)
				.ToList();
			Task.Run(() => Build(recipesDetails));
			return Result.Ok();
		}

		private RecipeDetails NewRecipeDetails(Recipe recipe)
		{
			var query = new GetDetailsFromIngredientsQuery(recipe.RecipeIngredients.ToDictionary());
			var recipeIngredientsDetails = _mediator.Query(query);
			return RecipeDetails.FromRecipeAndIngredientsDetails(recipe, recipeIngredientsDetails);
		}

		private void Build(IEnumerable<RecipeDetails> recipesDetails) => 
			_recipeDetailsRepository.AddRange(recipesDetails);
	}
}