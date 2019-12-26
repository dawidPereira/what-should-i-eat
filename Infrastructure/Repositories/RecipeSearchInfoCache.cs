using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Recipes.Repositories;
using Domain.RecipesDetails.Entities;
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

		public void Add(RecipeDetails recipeDetails)
		{
			var key = recipeDetails.Id
				.ToDictionaryKey(nameof(RecipeDetails));
			
			BackgroundJob.Enqueue(() =>
				_cachingProvider.Set(key, recipeDetails, TimeSpan.MaxValue));
		}

		public void AddRange(IEnumerable<RecipeDetails> recipeSearchInfos)
		{
			var searchInfosDictionary = recipeSearchInfos
				.ToDictionary(x => x.Id.ToDictionaryKey(nameof(RecipeDetails)), x => x);

			BackgroundJob.Enqueue(() =>
				_cachingProvider.SetAll(searchInfosDictionary, TimeSpan.MaxValue));
		}
	}
}