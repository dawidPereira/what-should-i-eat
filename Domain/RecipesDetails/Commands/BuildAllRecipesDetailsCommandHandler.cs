using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common.Mediators.Commands;
using Domain.Common.ValueObjects;
using Domain.RecipesDetails.Entities;
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

		public async Task<Result> Handle(BuildAllRecipesDetailsCommand command)
		{
			Build();
			return Result.Ok();
		}

		private async Task Build()
		{
			var recipesIds = await _recipeDetailsRepository.GetAllRecipesIds();
			var recipeDetailsCollection = new List<RecipeDetails>();
			foreach (var recipesId in recipesIds)
			{
				var recipeDetails = await _recipeDetailsFactory.Create(recipesId);
				recipeDetailsCollection.Add(recipeDetails);
			}
			await _recipeDetailsRepository.CreateNewOrReplaceExistingRange(recipeDetailsCollection);
		}
	}
}
