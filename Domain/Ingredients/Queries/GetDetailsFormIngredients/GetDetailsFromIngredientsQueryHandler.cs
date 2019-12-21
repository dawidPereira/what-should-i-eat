using Domain.Common.Mediators.Queries;
using Domain.Ingredients.Repositories;

namespace Domain.Ingredients.Queries.GetDetailsFormIngredients
{
	public class GetDetailsFromIngredientsQueryHandler : IQueryHandler<GetDetailsFromIngredientsQuery, AggregatedIngredientDetails>
	{
		private readonly IIngredientRepository _ingredientRepository;

		public GetDetailsFromIngredientsQueryHandler(IIngredientRepository ingredientRepository)
		{
			_ingredientRepository = ingredientRepository;
		}

		public AggregatedIngredientDetails Handle(GetDetailsFromIngredientsQuery query)
		{
			var ingredients = _ingredientRepository.GetByIds(query.GetIds());
		}
	}
}