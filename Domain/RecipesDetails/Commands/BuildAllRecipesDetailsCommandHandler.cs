using System.Linq;
using Domain.Common.Mediators.Commands;
using Domain.Common.ValueObjects;
using Domain.RecipesDetails.RecipeDetailsFactories;
using Domain.RecipesDetails.Repositories;

namespace Domain.RecipesDetails.Commands
{
	public class BuildAllRecipesDetailsCommandHandler : ICommandHandler<BuildAllRecipesDetailsCommand>
	{
		private readonly IRecipeDetailsFactory _recipeDetailsFactory;
		private readonly IRecipeDetailsRepository _recipeDetailsRepository;

		public BuildAllRecipesDetailsCommandHandler(IRecipeDetailsFactory recipeDetailsFactory, IRecipeDetailsRepository recipeDetailsRepository)
		{
			_recipeDetailsFactory = recipeDetailsFactory;
			_recipeDetailsRepository = recipeDetailsRepository;
		}

		public Result Handle(BuildAllRecipesDetailsCommand command)
		{
			Build();
			return Result.Ok();
		}

		private void Build()
		{
			var recipesIds = _recipeDetailsRepository.GetAllRecipesIds();
			var recipeDetailsCollection = recipesIds.Select(_recipeDetailsFactory.Create);
			_recipeDetailsRepository.CreateNewOrReplaceExistingRange(recipeDetailsCollection);
		}
	}
}