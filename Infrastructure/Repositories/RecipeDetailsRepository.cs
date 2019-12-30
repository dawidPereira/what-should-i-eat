using System;
using System.Collections.Generic;
using Domain.Common.Mediators;
using Domain.Ingredients.Queries.GetDetailsFormIngredients;
using Domain.Recipes.Queries.GetAllRecipeIds;
using Domain.Recipes.Queries.GetById;
using Domain.Recipes.Queries.GetRecipeIngredients;
using Domain.RecipesDetails.Entities;
using Domain.RecipesDetails.Repositories;
using EasyCaching.Core;
using Infrastructure.Common.Constants;
using Infrastructure.Mappers;

namespace Infrastructure.Repositories
{
	public class RecipeDetailsRepository : IRecipeDetailsRepository
	{
		private readonly IEasyCachingProvider _cachingProvider;
		private readonly IRecipeDetailsMapper _recipeDetailsMapper;
		private readonly IMediator _mediator;
		
		public RecipeDetailsRepository(IEasyCachingProviderFactory cachingProviderFactory, IMediator mediator, IRecipeDetailsMapper recipeDetailsMapper)
		{
			_mediator = mediator;
			_recipeDetailsMapper = recipeDetailsMapper;
			_cachingProvider = cachingProviderFactory.GetCachingProvider(RedisConstants.Name);
		}

//		public void Remove(string key) => BackgroundJob.Enqueue(() => _cachingProvider.Remove(key));
//
//		public void Add(RecipeInfo recipeDetails)
//		{
//			var key = recipeDetails.Id
//				.ToDictionaryKey(nameof(RecipeInfo));
//			
//			BackgroundJob.Enqueue(() =>
//				_cachingProvider.Set(key, recipeDetails, TimeSpan.MaxValue));
//		}
//
//		public void AddRange(IEnumerable<RecipeInfo> recipeSearchInfos)
//		{
//			var searchInfosDictionary = recipeSearchInfos
//				.ToDictionary(x => x.Id.ToDictionaryKey(nameof(RecipeInfo)), x => x);
//
//			BackgroundJob.Enqueue(() =>
//				_cachingProvider.SetAll(searchInfosDictionary, TimeSpan.MaxValue));
//		}
		public void Add(RecipeDetails recipeDetails)
		{
			throw new NotImplementedException();
		}

		public void Remove(string key)
		{
			throw new NotImplementedException();
		}

		public void AddRange(IEnumerable<RecipeDetails> recipeSearchInfos)
		{
			throw new NotImplementedException();
		}

		public IDictionary<Guid, double> GetRecipeIngredientById(Guid recipeId) =>
			_mediator.Query(new GetRecipeIngredientsQuery(recipeId));

		public IEnumerable<Guid> GetAllRecipesIds() => _mediator.Query(new GetAllRecipesIdsQuery());
		
		public Recipe GetRecipeById(Guid id)
		{
			var dto = _mediator.Query(new GetByIdQuery(id));
			return _recipeDetailsMapper.RecipeFromDto(dto);
		}

		public AggregatedIngredientsDetails GetAggregatedIngredientsDetailsByIds(IDictionary<Guid, double> ingredientsGrams)
		{
			var dto =  _mediator.Query(new GetAggregatedIngredientsDetailsQuery(ingredientsGrams));
			return _recipeDetailsMapper.AggregatedIngredientsDetailsFromDto(dto);
		}
	}
}