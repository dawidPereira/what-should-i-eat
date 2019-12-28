using EasyCaching.Core;
using Infrastructure.Common;

namespace Infrastructure.Repositories
{
	public class RecipeDetailsRepository //: IRecipeDetailsRepository
	{
		private readonly IEasyCachingProvider _cachingProvider;

		public RecipeDetailsRepository(IEasyCachingProviderFactory cachingProviderFactory)
		{
			_cachingProvider = cachingProviderFactory.GetCachingProvider(Constants.RedisName);
		}

//		public void Remove(string key) => BackgroundJob.Enqueue(() => _cachingProvider.Remove(key));
//
//		public void Add(RecipeDetails recipeDetails)
//		{
//			var key = recipeDetails.Id
//				.ToDictionaryKey(nameof(RecipeDetails));
//			
//			BackgroundJob.Enqueue(() =>
//				_cachingProvider.Set(key, recipeDetails, TimeSpan.MaxValue));
//		}
//
//		public void AddRange(IEnumerable<RecipeDetails> recipeSearchInfos)
//		{
//			var searchInfosDictionary = recipeSearchInfos
//				.ToDictionary(x => x.Id.ToDictionaryKey(nameof(RecipeDetails)), x => x);
//
//			BackgroundJob.Enqueue(() =>
//				_cachingProvider.SetAll(searchInfosDictionary, TimeSpan.MaxValue));
//		}
	}
}