using System.Linq;
using System.Threading.Tasks;
using Domain.Common.Mediators.Commands;
using Domain.Common.ValueObjects;
using Domain.Recipes.Repositories;

namespace Domain.Recipes.SearchInfos.Commands
{
	public class BuildRecipesSearchInfoDataCommandHandler : ICommandHandler<BuildRecipesSearchInfoDataCommand>
	{
		private readonly IRecipeRepository _recipeRepository;
		private readonly IRecipeSearchInfoRepository _recipeSearchInfoRepository;

		public BuildRecipesSearchInfoDataCommandHandler(IRecipeRepository recipeRepository,
			IRecipeSearchInfoRepository recipeSearchInfoRepository)
		{
			_recipeRepository = recipeRepository;
			_recipeSearchInfoRepository = recipeSearchInfoRepository;
		}

		public Result Handle(BuildRecipesSearchInfoDataCommand command)
		{
			Task.Run(() => Build(command));
			return Result.Ok();
		}

		
		private void Build(BuildRecipesSearchInfoDataCommand command)
		{
			var recipesSearchInfo = _recipeRepository.GetAll()
				.Select(x => x.CalculateSearchInfo())
				.ToList();

			_recipeSearchInfoRepository.AddRange(recipesSearchInfo);
		}
	}
}