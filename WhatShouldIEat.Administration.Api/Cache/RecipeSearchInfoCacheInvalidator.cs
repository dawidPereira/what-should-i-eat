using System;
using System.Collections.Generic;
using System.Linq;
using EasyCaching.Core;
using WhatShouldIEat.Administration.Api.Common;
using WhatShouldIEat.Administration.Domain.Common.Mediator;
using WhatShouldIEat.Administration.Domain.Recipes.Queries.SearchInfoQueries;
using WhatShouldIEat.Administration.Domain.Recipes.Queries.SearchInfoQueries.GetAllSearchInfos;
using WhatShouldIEat.Administration.Domain.Recipes.Queries.SearchInfoQueries.GetSearchInfosByIngredientId;

namespace WhatShouldIEat.Administration.Api.Cache
{
	public class RecipeSearchInfoCacheInvalidator : IRecipeSearchInfoCacheInvalidator
	{
		private readonly IMediator _mediator;
		private readonly IEasyCachingProvider _cachingProvider;

		public RecipeSearchInfoCacheInvalidator(IEasyCachingProviderFactory cachingProviderFactory, IMediator mediator)
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