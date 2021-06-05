using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common.Extensions;
using Domain.Common.Filters;
using Domain.Common.Mediators;
using Domain.Ingredients.Queries.GetDetailsFormIngredients;
using Domain.Recipes.Queries.GetAllRecipeIds;
using Domain.Recipes.Queries.GetById;
using Domain.Recipes.Queries.GetRecipeIngredients;
using Domain.RecipesDetails.Entities;
using Domain.RecipesDetails.Filters.FiltersCriteria;
using Domain.RecipesDetails.Repositories;
using EasyCaching.Core;
using Infrastructure.Common.Constants;
using Infrastructure.Common.Extensions;
using Infrastructure.Mappers.Recipes;

namespace Infrastructure.Repositories
{
	public class RecipeDetailsRepository : IRecipeDetailsRepository
	{
		private readonly IEasyCachingProvider _cachingProvider;
		private readonly IRecipeDetailsMapper _recipeDetailsMapper;
		private readonly IMediator _mediator;
		private readonly IFilterFactory<RecipeDetails, RecipeSearchFilterCriteria> _filterFactory;

		public RecipeDetailsRepository(IEasyCachingProviderFactory cachingProviderFactory,
			IMediator mediator,
			IRecipeDetailsMapper recipeDetailsMapper, IFilterFactory<RecipeDetails, RecipeSearchFilterCriteria> filterFactory)
		{
			_mediator = mediator;
			_recipeDetailsMapper = recipeDetailsMapper;
			_filterFactory = filterFactory;
			_cachingProvider = cachingProviderFactory.GetCachingProvider(RedisConstants.Name);
		}

		public async Task RemoveById(Guid recipeDetailsId)
		{
			var key = recipeDetailsId.ToDictionaryKey(nameof(RecipeDetails));
			_cachingProvider.Remove(key);
		}

		public async Task CreateNewOrReplaceExisting(RecipeDetails recipeDetails)
		{
			var key = recipeDetails.Id.Value
				.ToDictionaryKey(nameof(RecipeDetails));

			if (_cachingProvider.Exists(key))
				_cachingProvider.Remove(key);

			_cachingProvider.Set(key, recipeDetails, TimeSpan.FromDays(30));
		}

		public async Task CreateNewOrReplaceExistingRange(IEnumerable<RecipeDetails> recipeDetails)
		{
			foreach (var recipeDetail in recipeDetails)
			{
				await CreateNewOrReplaceExisting(recipeDetail);
			}
		}

		public void RemoveRange(IEnumerable<RecipeDetails> recipeDetails)
		{
			var keys = recipeDetails.Select(x => x.Id.Value
				.ToDictionaryKey(nameof(RecipeDetails)));

			_cachingProvider.RemoveAll(keys);
		}

		public IDictionary<Guid, double> GetRecipeIngredientByRecipeId(Guid recipeId) =>
			_mediator.Query(new GetRecipeIngredientsQuery(recipeId));

		public async Task<IEnumerable<Guid>> GetAllRecipesIds() => _mediator.Query(new GetAllRecipesIdsQuery());

		public async Task<IEnumerable<Guid>> GetRecipeIdsByIngredientId(Guid ingredientId)
		{
			//TODO: Have to be done with DeleteRecipeCommand
			throw new NotImplementedException();
		}

		public async Task<Recipe> GetRecipeById(Guid id)
		{
			var dto = _mediator.Query(new GetByIdQuery(id));
			return _recipeDetailsMapper.RecipeFromDto(dto);
		}

		public async Task<AggregatedIngredientsDetails> GetAggregatedIngredientsDetailsByIds(IDictionary<Guid, double> ingredientsGrams)
		{
			var dto =  _mediator.Query(new GetAggregatedIngredientsDetailsQuery(ingredientsGrams));
			return _recipeDetailsMapper.AggregatedIngredientsDetailsFromDto(dto);
		}

		public IEnumerable<RecipeDetails> FindRecipesDetails(RecipeSearchFilterCriteria filterCriteria)
		{
			var filters = _filterFactory.Build(filterCriteria);

			var recipes = _cachingProvider
				.GetByPrefix<RecipeDetails>(nameof(RecipeDetails))
				.Values;

			return recipes
				.Select(x => x.Value)
				.Where(x => filters.All(filter => filter.Satisfy(x)))
				.ToList();
		}
	}
}
