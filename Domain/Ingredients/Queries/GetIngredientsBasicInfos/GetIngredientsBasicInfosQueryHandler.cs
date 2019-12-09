using System.Collections.Generic;
using Domain.Ingredients.Repositories;
using Domain.Mediators.Query;

namespace Domain.Ingredients.Queries.GetIngredientsBasicInfos
{
	public class GetIngredientsBasicInfosQueryHandler : 
		IQueryHandler<GetIngredientsBasicInfosQuery, ICollection<IngredientBasicInfo>>
	{
		private readonly IIngredientRepository _ingredientRepository;

		public GetIngredientsBasicInfosQueryHandler(IIngredientRepository ingredientRepository) => 
			_ingredientRepository = ingredientRepository;

		public ICollection<IngredientBasicInfo> Handle(GetIngredientsBasicInfosQuery query) => 
			_ingredientRepository.GetBasicInfos() ?? new List<IngredientBasicInfo>();
	}
}