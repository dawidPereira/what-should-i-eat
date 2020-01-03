using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Common.Mediators;
using Domain.Ingredients.Queries.GetDetailsFormIngredients;
using Domain.Recipes.Queries.GetAllRecipeIds;
using Domain.Recipes.Queries.GetById;
using Domain.Recipes.Queries.GetRecipeIngredients;
using Domain.RecipesDetails.Entities;
using Domain.RecipesDetails.Repositories;
using EasyCaching.Core;
using Hangfire;
using Infrastructure.Common.Constants;
using Infrastructure.Common.Extensions;
using Infrastructure.Mappers.Recipes;
using Infrastructure.Repositories.DataAccess.Events;

namespace Infrastructure.Repositories
{
	public class RecipeDetailsRepository : IRecipeDetailsRepository
	{
		private readonly IEasyCachingProvider _cachingProvider;
		private readonly IRecipeDetailsMapper _recipeDetailsMapper;
		private readonly IEventDataReader _eventDataReader;
		private readonly IEventDataWriter _eventDataWriter;
		private readonly IMediator _mediator;
		
		public RecipeDetailsRepository(IEasyCachingProviderFactory cachingProviderFactory, 
			IMediator mediator, 
			IRecipeDetailsMapper recipeDetailsMapper, 
			IEventDataReader eventDataReader, 
			IEventDataWriter eventDataWriter)
		{
			_mediator = mediator;
			_recipeDetailsMapper = recipeDetailsMapper;
			_eventDataReader = eventDataReader;
			_eventDataWriter = eventDataWriter;
			_cachingProvider = cachingProviderFactory.GetCachingProvider(RedisConstants.Name);
		}

		public void Remove(string key) => BackgroundJob.Enqueue(() => _cachingProvider.Remove(key));

		public void Add(RecipeDetails recipeDetails)
		{
			var key = recipeDetails.Id.Value
				.ToDictionaryKey(nameof(RecipeDetails));
			
			BackgroundJob.Enqueue(() =>
				_cachingProvider.Set(key, recipeDetails, TimeSpan.MaxValue));
		}

		public void AddRange(IEnumerable<RecipeDetails> recipeDetails)
		{
			var searchInfosDictionary = recipeDetails
				.ToDictionary(x => x.Id.Value.ToDictionaryKey(nameof(RecipeDetails)), x => x);

			BackgroundJob.Enqueue(() =>
				_cachingProvider.SetAll(searchInfosDictionary, TimeSpan.MaxValue));
		}

		public IDictionary<Guid, double> GetRecipeIngredientByRecipeId(Guid recipeId) =>
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