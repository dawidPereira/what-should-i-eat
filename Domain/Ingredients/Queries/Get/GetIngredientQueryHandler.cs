using Domain.Common;
using Domain.Common.Mediators.Queries;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Repositories;

namespace Domain.Ingredients.Queries.Get
{
	public class GetIngredientQueryHandler : IQueryHandler<GetIngredientQuery, IngredientDto>
	{
		private readonly IIngredientRepository _ingredientRepository;

		public GetIngredientQueryHandler(IIngredientRepository ingredientRepository) =>
			_ingredientRepository = ingredientRepository;

		public IngredientDto Handle(GetIngredientQuery query)
		{
			var ingredient = _ingredientRepository.GetById(query.IngredientId.Value)
			                 ?? Exceptions<Ingredient>.ThrowNotFoundException(nameof(Ingredient), query.IngredientId.ToString());
			return IngredientDto.FromIngredient(ingredient);
		}
	}
}