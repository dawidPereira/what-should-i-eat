using Domain.Common;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Repositories;
using Domain.Mediators.Query;

namespace Domain.Ingredients.Queries.GetIngredient
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