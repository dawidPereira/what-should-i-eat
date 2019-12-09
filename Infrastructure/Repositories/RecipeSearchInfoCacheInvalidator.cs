using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Recipes.Queries.SearchInfoQueries;
using Domain.Recipes.Queries.SearchInfoQueries.GetAllSearchInfos;
using Domain.Recipes.Queries.SearchInfoQueries.GetSearchInfosByIngredientId;
using Domain.Recipes.Repositories;
using EasyCaching.Core;
using Infrastructure.Common;
using Infrastructure.Mediator;

namespace Infrastructure.Repositories
{
	public class RecipeSearchInfoRepository : IRecipeSearchInfoRepository
	{
		private readonly IMediator _mediator;
		private readonly IEasyCachingProvider _cachingProvider;

		public RecipeSearchInfoRepository(IEasyCachingProviderFactory cachingProviderFactory, IMediator mediator)
		{
			_mediator = mediator;
			_cachingProvider = cachingProviderFactory.GetCachingProvider(Constants.RedisName);
		}

		public void Remove(string key) => _cachingProvider.Remove(key);

		public void Update(RecipeSearchInfo recipeSearchInfo)
		{
			var recipeSearchInfoDictionary = new Dictionary<string, RecipeSearchInfo>
			{
				{recipeSearchInfo.Id.ToString(), recipeSearchInfo}
			};
			_cachingProvider.Set(Constants.RecipeSearchInfo, recipeSearchInfoDictionary , TimeSpan.MaxValue);
		}


		public void BuildRecipeSearchInfo()
		{
			var recipesSearchInfos = _mediator.Query(new GetAllSearchInfosQuery())
				.ToDictionary(x => x.Id.ToString(), x => x);
			var recipeSearchInfoDictionary = new Dictionary<string, IDictionary<string,RecipeSearchInfo>>
			{
				{Constants.RecipeSearchInfo, recipesSearchInfos}
			};

			_cachingProvider.SetAll(recipeSearchInfoDictionary, TimeSpan.MaxValue);
		}

		public void UpdateRecipeSearchInfoByIngredientId(Guid id)
		{
			var recipesSearchInfos = _mediator.Query(new GetSearchInfosByIngredientIdQuery(id))
				.ToDictionary(x => x.Id.ToString(), x => x);
			var recipeSearchInfoDictionary = new Dictionary<string, IDictionary<string,RecipeSearchInfo>>
			{
				{Constants.RecipeSearchInfo, recipesSearchInfos}
			};
			
			_cachingProvider.SetAll(recipeSearchInfoDictionary, TimeSpan.MaxValue);
		}
	}
}