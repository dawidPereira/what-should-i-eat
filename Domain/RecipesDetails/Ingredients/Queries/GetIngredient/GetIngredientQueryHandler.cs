using Domain.Common;
using Domain.Common.Mediators.Queries;
using Domain.RecipesDetails.Ingredients.Entities;
using Domain.RecipesDetails.Ingredients.Repositories;

namespace Domain.RecipesDetails.Ingredients.Queries.GetIngredient
{
	public class GetIngredientQueryHandler : IQueryHandler<GetIngredientQuery, IngredientDto>
	{
		private readonly IIngredientRepository _ingredientRepository;

		public GetIngredientQueryHandler(IIngredientRepository ingredientRepository) =>
			_ingredientRepository = ingredientRepository;

		public IngredientDto Handle(GetIngredientQuery query) => _ingredientRepository.GetById(query.Id)?.ToDto() ??
			Exceptions<IngredientDto>.ThrowNotFoundException(nameof(Ingredient), query.Id.ToString());
	}
}