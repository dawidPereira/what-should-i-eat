using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Common.Extensions;
using Domain.Common.Mediators;
using Domain.Ingredients.Queries.GetDetailsFormIngredients;
using Domain.Recipes.Queries.GetAllRecipeIds;
using Domain.Recipes.Queries.GetById;
using Domain.Recipes.Queries.GetRecipeIngredients;
using Domain.RecipesDetails.Entities;
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
		
		public RecipeDetailsRepository(IEasyCachingProviderFactory cachingProviderFactory, 
			IMediator mediator, 
			IRecipeDetailsMapper recipeDetailsMapper)
		{
			_mediator = mediator;
			_recipeDetailsMapper = recipeDetailsMapper;
			_cachingProvider = cachingProviderFactory.GetCachingProvider(RedisConstants.Name);
		}

		public void RemoveById(Guid recipeDetailsId)
		{
			var key = recipeDetailsId.ToDictionaryKey(nameof(RecipeDetails));
			_cachingProvider.Remove(key);
		}

		public void CreateNewOrReplaceExisting(RecipeDetails recipeDetails)
		{
			var key = recipeDetails.Id.Value
				.ToDictionaryKey(nameof(RecipeDetails));

			if (_cachingProvider.Exists(key))
				_cachingProvider.Remove(key);
			
			_cachingProvider.Set(key, recipeDetails, TimeSpan.MaxValue);
		}

		public void CreateNewOrReplaceExistingRange(IEnumerable<RecipeDetails> recipeDetails) => 
			recipeDetails.ForEach(CreateNewOrReplaceExisting);

		public void RemoveRange(IEnumerable<RecipeDetails> recipeDetails)
		{
			var keys = recipeDetails.Select(x => x.Id.Value
				.ToDictionaryKey(nameof(RecipeDetails)));
			
			_cachingProvider.RemoveAll(keys);
		}

		public IDictionary<Guid, double> GetRecipeIngredientByRecipeId(Guid recipeId) =>
			_mediator.Query(new GetRecipeIngredientsQuery(recipeId));

		public IEnumerable<Guid> GetAllRecipesIds() => _mediator.Query(new GetAllRecipesIdsQuery());
		public IEnumerable<Guid> GetRecipeIdsByIngredientId(Guid ingredientId)
		{
			throw new NotImplementedException();
		}

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