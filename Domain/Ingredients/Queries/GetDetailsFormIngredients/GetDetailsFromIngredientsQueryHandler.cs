using System.Linq;
using Domain.Common.Mediators.Queries;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Repositories;

namespace Domain.Ingredients.Queries.GetDetailsFormIngredients
{
	public class GetDetailsFromIngredientsQueryHandler : IQueryHandler<GetDetailsFromIngredientsQuery, AggregatedIngredientsDetailsDto>
	{
		private readonly IIngredientRepository _ingredientRepository;

		public GetDetailsFromIngredientsQueryHandler(IIngredientRepository ingredientRepository)
		{
			_ingredientRepository = ingredientRepository;
		}

		public AggregatedIngredientsDetailsDto Handle(GetDetailsFromIngredientsQuery query)
		{
			var ingredients = _ingredientRepository.GetByIds(query.GetIds());
			var ingredientsGrams = ingredients
				.Select(x => new IngredientGrams(x, query.GetGramsForIngredient(x.Id.Value)));
			var ingredientsGramsCollection = new IngredientsGramsCollection(ingredientsGrams);
			return AggregatedIngredientsDetailsDto.FromIngredientsGramsCollection(ingredientsGramsCollection);
		}
	}
}