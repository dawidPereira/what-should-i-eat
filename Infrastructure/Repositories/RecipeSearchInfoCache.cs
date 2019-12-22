using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Recipes.Repositories;
using Domain.RecipesDetails.SearchInfos;
using EasyCaching.Core;
using Hangfire;
using Infrastructure.Common;
using Infrastructure.Common.Extensions;

namespace Infrastructure.Repositories
{
	public class RecipeSearchInfoRepository : IRecipeSearchInfoRepository
	{
		private readonly IEasyCachingProvider _cachingProvider;

		public RecipeSearchInfoRepository(IEasyCachingProviderFactory cachingProviderFactory)
		{
			_cachingProvider = cachingProviderFactory.GetCachingProvider(Constants.RedisName);
		}

		public void Remove(string key) => BackgroundJob.Enqueue(() => _cachingProvider.Remove(key));

		public void Add(RecipeSearchInfo recipeSearchInfo)
		{
			var key = recipeSearchInfo.Id
				.ToDictionaryKey(nameof(RecipeSearchInfo));
			
			BackgroundJob.Enqueue(() =>
				_cachingProvider.Set(key, recipeSearchInfo, TimeSpan.MaxValue));
		}

		public void AddRange(IEnumerable<RecipeSearchInfo> recipeSearchInfos)
		{
			var searchInfosDictionary = recipeSearchInfos
				.ToDictionary(x => x.Id.ToDictionaryKey(nameof(RecipeSearchInfo)), x => x);

			BackgroundJob.Enqueue(() =>
				_cachingProvider.SetAll(searchInfosDictionary, TimeSpan.MaxValue));
		}
	}
}